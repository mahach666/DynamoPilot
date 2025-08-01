using CoreNodeModels;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoPilot.Nodes
{
    [NodeName("SelectType")]
    [NodeCategory("PilotNodes.Type.Select")]
    [NodeDescription("Выбрать один тип из репозитория")]
    [IsDesignScriptCompatible]
    [OutPortNames("type")]
    [OutPortTypes("PilotType")]
    [OutPortDescriptions("Выбранный тип")]
    public class PilotTypeDropdown : DSDropDownBase
    {
        public PilotTypeDropdown() : base("SelectType") { }

        [JsonConstructor]
        private PilotTypeDropdown(IEnumerable<PortModel> inPorts,
                                  IEnumerable<PortModel> outPorts)
            : base("SelectType", inPorts, outPorts) { }

        protected override SelectionState PopulateItemsCore(string _)
        {
            Items.Clear();

            var repo = StaticMetadata.ObjectsRepository;
            if (repo == null) return SelectionState.Done;

            foreach (var t in repo.GetTypes().OrderBy(t => t.Title))
                Items.Add(new DynamoDropDownItem($"{t.Title} - {t.Name}", t.Id));

            SelectedIndex = Items.Count > 0 ? 0 : -1;
            return SelectionState.Restore;
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            if (SelectedIndex < 0 || SelectedIndex >= Items.Count)
            {
                yield return AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildNullNode());
                yield break;
            }

            var idNode = AstFactory.BuildIntNode((int)Items[SelectedIndex].Item);

            var callNode = AstFactory.BuildFunctionCall(
                new Func<int, PType>(Type.Select.GetTypeById),
                new List<AssociativeNode> { idNode });

            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0), callNode);
        }
    }
}
