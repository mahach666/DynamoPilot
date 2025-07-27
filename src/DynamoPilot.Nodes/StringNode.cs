using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Pilot String")]
    [NodeCategory("Pilot.String")]
    [NodeDescription("Операции со строками")]
    [IsDesignScriptCompatible]
    [InPortNames("text1", "text2")]
    [InPortTypes("string", "string")]
    [InPortDescriptions("Первая строка", "Вторая строка")]
    [OutPortNames("concatenated", "length1", "length2", "upper")]
    [OutPortTypes("string", "int", "int", "string")]
    [OutPortDescriptions("Объединенная строка", "Длина первой строки", "Длина второй строки", "Верхний регистр")]
    [Export(typeof(NodeModel))]
    public class StringNode : NodeModel
    {
        public StringNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private StringNode(IEnumerable<PortModel> inPorts,
                          IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            var concat = GetAstIdentifierForOutputIndex(0);
            var len1 = GetAstIdentifierForOutputIndex(1);
            var len2 = GetAstIdentifierForOutputIndex(2);
            var upper = GetAstIdentifierForOutputIndex(3);

            var input1 = inputAstNodes[0];
            var input2 = inputAstNodes[1];

            return new[]
            {
                AstFactory.BuildAssignment(concat, AstFactory.BuildBinaryExpression(input1, input2, ProtoCore.DSASM.Operator.add)),
                AstFactory.BuildAssignment(len1, AstFactory.BuildFunctionCall("String.Length", new List<AssociativeNode> { input1 })),
                AstFactory.BuildAssignment(len2, AstFactory.BuildFunctionCall("String.Length", new List<AssociativeNode> { input2 })),
                AstFactory.BuildAssignment(upper, AstFactory.BuildFunctionCall("String.ToUpper", new List<AssociativeNode> { input1 }))
            };
        }
    }
}