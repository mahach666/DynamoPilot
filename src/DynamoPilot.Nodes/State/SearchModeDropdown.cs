using Ascon.Pilot.SDK;
using CoreNodeModels;
using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{
    [NodeName("SelectSearchMode")]
    [NodeCategory("PilotNodes.Search.Enums")]
    [NodeDescription("Выбрать SearchMode")]
    [IsDesignScriptCompatible]
    [OutPortNames("mode")]
    [OutPortTypes("SearchMode")]
    [OutPortDescriptions("Выбранное SearchMode")]
    public class SearchModeDropdown : DSDropDownBase
    {
        public SearchModeDropdown() : base("SelectObjectState") { }

        [JsonConstructor]
        private SearchModeDropdown(IEnumerable<PortModel> inPorts,
                                    IEnumerable<PortModel> outPorts)
            : base("SelectObjectState", inPorts, outPorts) { }

        protected override SelectionState PopulateItemsCore(string _)
        {
            Items.Clear();

            // Получаем все состояния из Constants
            var states = Enum.GetNames(typeof(SearchMode));

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
            
            // Парсим строку в ObjectState
            var callNode = AstFactory.BuildFunctionCall(
                new Func<string, SearchMode>(Utils.Parsers.ParseSearchMode),
                new List<AssociativeNode> { AstFactory.BuildStringNode(selectedState) });

            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0), callNode);
        }
    }
} 