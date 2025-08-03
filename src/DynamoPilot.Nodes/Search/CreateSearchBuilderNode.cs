using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{
    [NodeName("CreateSearchBuilder")]
    [NodeCategory("PilotNodes.Search.SearchBuilder")]
    [NodeDescription("Создает новый построитель запросов для поиска")]
    [IsDesignScriptCompatible]
    [OutPortNames("queryBuilder")]
    [OutPortTypes("PQueryBuilder")]
    [OutPortDescriptions("Построитель запросов для поиска")]
    public class CreateSearchBuilderNode : NodeModel
    {
        public CreateSearchBuilderNode()
        {
            // Устанавливаем имя нода
            Name = "CreateSearchBuilder";
            
            // Добавляем выходной порт
            OutPorts.Add(new PortModel(PortType.Output, this, new PortData("queryBuilder", "Построитель запросов для поиска")));
            
            // Регистрируем нод для обновления при каждом запуске
            RegisterAllPorts();
        }

        [JsonConstructor]
        private CreateSearchBuilderNode(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts)
        {
            Name = "CreateSearchBuilder";
            RegisterAllPorts();
        }


        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // Создаем вызов статического метода CreateSearchBuilder из DynamoPilot.Zero
            var callNode = AstFactory.BuildFunctionCall(
                new Func<DynamoPilot.Data.Wrappers.PQueryBuilder>(Search.SearchBuilder.CreateSearchBuilder),
                new List<AssociativeNode>());

            // Возвращаем присваивание результата выходному порту
            yield return AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0), callNode);
        }
    }
}
