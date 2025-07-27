using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Pilot Math")]
    [NodeCategory("Pilot.Math")]
    [NodeDescription("Выполняет математические операции с двумя числами")]
    [IsDesignScriptCompatible]
    [InPortNames("a", "b")]
    [InPortTypes("double", "double")]
    [InPortDescriptions("Первое число", "Второе число")]
    [OutPortNames("sum", "difference", "product", "quotient")]
    [OutPortTypes("double", "double", "double", "double")]
    [OutPortDescriptions("Сумма", "Разность", "Произведение", "Частное")]
    [Export(typeof(NodeModel))]
    public class MathNode : NodeModel
    {
        public MathNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private MathNode(IEnumerable<PortModel> inPorts,
                          IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            var a = GetAstIdentifierForOutputIndex(0);
            var b = GetAstIdentifierForOutputIndex(1);
            var c = GetAstIdentifierForOutputIndex(2);
            var d = GetAstIdentifierForOutputIndex(3);

            var inputA = inputAstNodes[0];
            var inputB = inputAstNodes[1];

            return new[]
            {
                AstFactory.BuildAssignment(a, AstFactory.BuildBinaryExpression(inputA, inputB, ProtoCore.DSASM.Operator.add)),
                AstFactory.BuildAssignment(b, AstFactory.BuildBinaryExpression(inputA, inputB, ProtoCore.DSASM.Operator.sub)),
                AstFactory.BuildAssignment(c, AstFactory.BuildBinaryExpression(inputA, inputB, ProtoCore.DSASM.Operator.mul)),
                AstFactory.BuildAssignment(d, AstFactory.BuildBinaryExpression(inputA, inputB, ProtoCore.DSASM.Operator.div))
            };
        }
    }
}