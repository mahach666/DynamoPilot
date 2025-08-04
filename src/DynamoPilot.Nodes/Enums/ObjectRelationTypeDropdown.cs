using Ascon.Pilot.SDK;
using CoreNodeModels;
using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{
    [NodeName("ObjectRelationType")]
    [NodeCategory("PilotNodes.Enums")]
    [NodeDescription("Выбрать тип связи")]
    [IsDesignScriptCompatible]
    [OutPortNames("state")]
    [OutPortTypes("ObjectState")]
    [OutPortDescriptions("Выбранный тип связи")]
    public class ObjectRelationTypeDropdown : DSDropDownBase
    {
        public ObjectRelationTypeDropdown() : base("SelectObjectState") { }

        [JsonConstructor]
        private ObjectRelationTypeDropdown(IEnumerable<PortModel> inPorts,
                                    IEnumerable<PortModel> outPorts)
            : base("SelectObjectState", inPorts, outPorts) { }

        protected override SelectionState PopulateItemsCore(string _)
        {
            Items.Clear();

            var states = Enum.GetNames(typeof(ObjectRelationType));

            foreach (var state in states)
            {
                Items.Add(new DynamoDropDownItem(state, state));
            }

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

            var selectedState = Items[SelectedIndex].Item.ToString();
            
            var callNode = AstFactory.BuildFunctionCall(
                new Func<string, ObjectRelationType>(Utils.Parsers.ParseRelationType),
                new List<AssociativeNode> { AstFactory.BuildStringNode(selectedState) });

            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0), callNode);
        }
    }
} 