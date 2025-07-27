using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Test Node")]
    [NodeCategory("Pilot.Test")]
    [NodeDescription("Простая тестовая нода")]
    [IsDesignScriptCompatible]
    [OutPortNames("result")]
    [OutPortTypes("string")]
    [OutPortDescriptions("Результат теста")]
    [Export(typeof(NodeModel))]
    public class TestNode : NodeModel
    {
        public TestNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private TestNode(IEnumerable<PortModel> inPorts,
                        IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("Test Node Loaded Successfully!"))
            };
        }
    }
}