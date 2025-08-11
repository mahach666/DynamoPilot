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
    [NodeName("SelectDocuments")]
    [NodeCategory("PilotNodes.DataObject.Get")]
    [NodeDescription("Открывает диалог выбора документов Pilot и возвращает выбранные объекты")] 
    [IsDesignScriptCompatible]
    [OutPortNames("documents")]
    [OutPortTypes("PilotDataObject[]")]
    [OutPortDescriptions("Список выбранных объектов данных")] 
    public class SelectDocumentsNode : NodeModel
    {
        [JsonProperty("selectedIds")]
        private List<string> SelectedIds { get; set; } = new();
        public SelectDocumentsNode()
        {
            // Порты создаются из атрибутов OutPortNames/OutPortTypes
            RegisterAllPorts();
        }

        [JsonConstructor]
        private SelectDocumentsNode(IEnumerable<PortModel> inPorts,
            IEnumerable<PortModel> outPorts) : base(inPorts, outPorts)
        {
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            if (SelectedIds == null || SelectedIds.Count == 0)
            {
                yield return AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode());
                yield break;
            }

            var idNodes = SelectedIds.Select(s => (AssociativeNode)AstFactory.BuildStringNode(s)).ToList();
            var listExpr = AstFactory.BuildExprList(idNodes);

            var buildObjectsNode = AstFactory.BuildFunctionCall(
                new Func<IList<string>, PDataObject[]>(global::DataObject.Get.GetByStrGuidsArray),
                new List<AssociativeNode> { listExpr });

            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0), buildObjectsNode);
        }

        internal void ExecuteSelection()
        {
            var service = StaticMetadata.PilotDialogService;
            if (service == null)
                return;

            var result = service.ShowDocumentsSelectorDialog();
            SelectedIds = result?.Select(d => d.Id.ToString()).ToList() ?? new List<string>();
            OnNodeModified(forceExecute: true);
        }
    }

    public static class SelectionStorage
    {
        private static readonly ConcurrentDictionary<Guid, List<string>> NodeIdToSelection = new();
        private static readonly ConcurrentDictionary<Guid, PDataObject[]> NodeIdToObjects = new();

        public static void SetSelectedIds(Guid nodeId, List<string> ids)
        {
            NodeIdToSelection[nodeId] = ids ?? new List<string>();
        }

        public static IList<string> GetSelectedIds(string nodeId)
        {
            if (!Guid.TryParse(nodeId, out var guid))
                return Array.Empty<string>();

            if (NodeIdToSelection.TryGetValue(guid, out var list) && list != null)
                return list;

            return Array.Empty<string>();
        }

        public static void SetSelectedObjects(Guid nodeId, PDataObject[] objects)
        {
            NodeIdToObjects[nodeId] = objects ?? Array.Empty<PDataObject>();
        }

        public static PDataObject[] GetSelectedObjects(string nodeId)
        {
            if (!Guid.TryParse(nodeId, out var guid))
                return Array.Empty<PDataObject>();

            if (NodeIdToObjects.TryGetValue(guid, out var objs) && objs != null)
                return objs;

            return Array.Empty<PDataObject>();
        }
    }

    public class SelectDocumentsNodeView : INodeViewCustomization<SelectDocumentsNode>
    {
        public void CustomizeView(SelectDocumentsNode model, NodeView nodeView)
        {
            var button = new Button
            {
                Content = "Выбрать документы",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0, 4, 0, 4)
            };

            button.Click += (_, __) => model.ExecuteSelection();

            // Place button into the main input grid
            nodeView.inputGrid.Children.Add(button);
        }

        public void Dispose()
        {
        }
    }
}


