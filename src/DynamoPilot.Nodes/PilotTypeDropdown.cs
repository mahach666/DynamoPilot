using CoreNodeModels;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamoPilot.Nodes
{
    [NodeName("Pilot Type")]
    [NodeCategory("Pilot.Metadata")]
    [NodeDescription("Выбрать один тип из репозитория")]
    [IsDesignScriptCompatible]
    [OutPortNames("type")]
    [OutPortTypes("PilotType")]
    [OutPortDescriptions("Выбранный тип")]
    public class PilotTypeDropdown : DSDropDownBase
    {
        public PilotTypeDropdown() : base("Pilot Type") { }

        [JsonConstructor]
        private PilotTypeDropdown(IEnumerable<PortModel> inPorts,
                                  IEnumerable<PortModel> outPorts)
            : base("Pilot Type", inPorts, outPorts) { }

        // ───────────────── 1. Заполняем Items ──────────────────────────
        protected override SelectionState PopulateItemsCore(string _)
        {
            Items.Clear();

            var repo = StaticMetadata.ObjectsRepository;
            if (repo == null)
                return SelectionState.Done;

            // сортируем и сразу кладём в ObservableCollection
            var sorted = repo.GetTypes()
                             .OrderBy(t => t.Title)
                             .Select(t => new DynamoDropDownItem(t.Title, t.Id));

            Items = new ObservableCollection<DynamoDropDownItem>(sorted);

            SelectedIndex = Items.Count > 0 ? 0 : -1;
            return SelectionState.Restore;   // восстановить прежний выбор
        }

        // ───────────────── 2. AST: Guid → GetTypeById() ────────────────
        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            if (SelectedIndex < 0 || SelectedIndex >= Items.Count)
            {
                yield return AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildNullNode());
                yield break;
            }

            var guidStr = ((Guid)Items[SelectedIndex].Item).ToString();
            var guidNode = AstFactory.BuildStringNode(guidStr);

            var callNode = AstFactory.BuildFunctionCall(
                "Pilot.Nodes.PilotTypeDropdown",      // FQN-класс
                nameof(GetTypeById),                  // метод
                new List<AssociativeNode> { guidNode });

            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0),
                callNode);
        }

        // ───────────────── 3. .NET-функция, к которой обращается DS ────
        internal static PilotType GetTypeById(string guid)
        {
            return int.TryParse(guid, out var id)
                 ? StaticMetadata.ObjectsRepository?.GetType(id)
                 : null;
        }
    }
}
