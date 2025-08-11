using Autodesk.DesignScript.Runtime;
using Ascon.Pilot.SDK;
using Dynamo.Controls;
using Dynamo.Graph.Nodes;
using Dynamo.Wpf;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DynamoPilot.Nodes.Dialogs
{
    [NodeName("SelectDocumentsWithOptions")]
    [NodeCategory("PilotNodes.DataObject.Get")]
    [NodeDescription("Открывает диалог выбора документов Pilot c опциями и возвращает выбранные объекты")]
    [IsDesignScriptCompatible]
    [InPortNames("options")]
    [InPortTypes("var")]
    [InPortDescriptions("Опции диалога Pilot")]
    [OutPortNames("documents")]
    [OutPortTypes("PilotDataObject[]")]
    [OutPortDescriptions("Список выбранных объектов данных")] 
    public class SelectDocumentsWithOptionsNode : NodeModel
    {
        [JsonProperty("selectedIds")] private List<string> SelectedIds { get; set; } = new();

        public SelectDocumentsWithOptionsNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private SelectDocumentsWithOptionsNode(IEnumerable<PortModel> inPorts,
            IEnumerable<PortModel> outPorts) : base(inPorts, outPorts)
        {
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // 1) Захватываем опции, пришедшие на вход, и сохраняем их в сторедж по идентификатору ноды
            var nodeIdNode = AstFactory.BuildStringNode(GUID.ToString());
            var optionsInputNode = (inputAstNodes != null && inputAstNodes.Count > 0)
                ? inputAstNodes[0]
                : AstFactory.BuildNullNode();

            var captureCall = AstFactory.BuildFunctionCall(
                new Func<string, object, object>(OptionsStorage.Capture),
                new List<AssociativeNode> { nodeIdNode, optionsInputNode });

            // 2) Формируем выход на основе текущего выбора, зависящий от captureCall,
            //    чтобы рантайм гарантированно выполнил захват опций до вычисления выхода
            var outputId = GetAstIdentifierForOutputIndex(0);

            if (SelectedIds == null || SelectedIds.Count == 0)
            {
                var emptyCall = AstFactory.BuildFunctionCall(
                    new Func<PDataObject[]>(Empty), new List<AssociativeNode>());
                var seqEmpty = AstFactory.BuildFunctionCall(
                    new Func<object, PDataObject[], PDataObject[]>(ReturnAfter),
                    new List<AssociativeNode> { captureCall, emptyCall });
                yield return AstFactory.BuildAssignment(outputId, seqEmpty);
                yield break;
            }

            var idNodes = SelectedIds.Select(s => (AssociativeNode)AstFactory.BuildStringNode(s)).ToList();
            var listExpr = AstFactory.BuildExprList(idNodes);

            var buildObjectsNode = AstFactory.BuildFunctionCall(
                new Func<IList<string>, PDataObject[]>(global::DataObject.Get.GetByStrGuidsArray),
                new List<AssociativeNode> { listExpr });

            var seq = AstFactory.BuildFunctionCall(
                new Func<object, PDataObject[], PDataObject[]>(ReturnAfter),
                new List<AssociativeNode> { captureCall, buildObjectsNode });

            yield return AstFactory.BuildAssignment(outputId, seq);
        }

        internal void ExecuteSelection()
        {
            var service = StaticMetadata.PilotDialogService;
            if (service == null)
                return;

            var options = OptionsStorage.Get(GUID.ToString());
            var result = service.ShowDocumentsSelectorDialog(options);
            SelectedIds = result?.Select(d => d.Id.ToString()).ToList() ?? new List<string>();
            OnNodeModified(forceExecute: true);
        }

        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static PDataObject[] ReturnAfter(object _, PDataObject[] value)
        {
            return value;
        }

        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static PDataObject[] Empty()
        {
            return Array.Empty<PDataObject>();
        }

        // Локальное хранилище опций в той же сборке, чтобы избежать
        // потенциальных проблем с контекстами загрузки
        public static class OptionsStorage
        {
            private static readonly ConcurrentDictionary<Guid, object> NodeIdToOptions = new();

            [IsDesignScriptCompatible]
            [IsVisibleInDynamoLibrary(false)]
            public static object Capture(string nodeId, object options)
            {
                if (!Guid.TryParse(nodeId, out var guid))
                    return options;

                if (options == null)
                {
                    NodeIdToOptions.TryRemove(guid, out _);
                    return null;
                }

                NodeIdToOptions[guid] = options;
                return options;
            }

            public static PPilotDialogOptions Get(string nodeId)
            {
                if (!Guid.TryParse(nodeId, out var guid))
                    return null;
                if (!NodeIdToOptions.TryGetValue(guid, out var stored) || stored == null)
                    return null;

                if (stored is PPilotDialogOptions popts)
                    return popts;

                try
                {
                    var unwrapMethod = stored.GetType().GetMethod("Unwrap");
                    if (unwrapMethod != null)
                    {
                        var unwrapped = unwrapMethod.Invoke(stored, null);
                        if (unwrapped is IPilotDialogOptions sdkOptions)
                        {
                            return new PPilotDialogOptions(sdkOptions);
                        }
                    }
                }
                catch
                {
                }

                return null;
            }
        }
    }

    public class SelectDocumentsWithOptionsNodeView : INodeViewCustomization<SelectDocumentsWithOptionsNode>
    {
        public void CustomizeView(SelectDocumentsWithOptionsNode model, NodeView nodeView)
        {
            var button = new Button
            {
                Content = "Выбрать документы",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 4, 0, 4)
            };

            button.Click += (_, __) => model.ExecuteSelection();

            nodeView.inputGrid.Children.Add(button);
        }

        public void Dispose()
        {
        }
    }
}


