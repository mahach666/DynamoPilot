using Dynamo.Controls;
using Dynamo.Graph.Nodes;
using Dynamo.Wpf;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DynamoPilot.Nodes.Dialogs
{
	[NodeName("SelectPositions")]
	[NodeCategory("PilotNodes.OrganisationUnit.Get")]
	[NodeDescription("Открывает диалог выбора должностей Pilot и возвращает выбранные позиции")] 
	[IsDesignScriptCompatible]
	[OutPortNames("positions")]
	[OutPortTypes("PilotOrganisationUnit[]")]
	[OutPortDescriptions("Список выбранных должностей")] 
	public class SelectPositionsNode : NodeModel
	{
		[JsonProperty("selectedIds")]
		private List<int> SelectedIds { get; set; } = new();
		public SelectPositionsNode()
		{
			// Порты создаются из атрибутов OutPortNames/OutPortTypes
			RegisterAllPorts();
		}

		[JsonConstructor]
		private SelectPositionsNode(IEnumerable<PortModel> inPorts,
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

			var itemNodes = SelectedIds
				.Select(id => (AssociativeNode)AstFactory.BuildFunctionCall(
					new Func<int, POrganisationUnit>(global::OrganisationUnit.Get.GetOrganisationUnit),
					new List<AssociativeNode> { AstFactory.BuildIntNode(id) }))
				.ToList();

			var listExpr = AstFactory.BuildExprList(itemNodes);

			yield return AstFactory.BuildAssignment(
				GetAstIdentifierForOutputIndex(0), listExpr);
		}

		internal void ExecuteSelection()
		{
			var service = StaticMetadata.PilotDialogService;
			if (service == null)
				return;

			var result = service.ShowPositionSelectorDialog();
			SelectedIds = result?.Select(o => o.Id).ToList() ?? new List<int>();
			OnNodeModified(forceExecute: true);
		}
	}

	public class SelectPositionsNodeView : INodeViewCustomization<SelectPositionsNode>
	{
		public void CustomizeView(SelectPositionsNode model, NodeView nodeView)
		{
			var button = new Button
			{
				Content = "Выбрать должности",
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



