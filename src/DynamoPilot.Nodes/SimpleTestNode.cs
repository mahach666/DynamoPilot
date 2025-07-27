using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Simple Test")]
    [NodeCategory("Pilot.Test")]
    [NodeDescription("Простая тестовая нода")]
    [IsDesignScriptCompatible]
    [OutPortNames("result")]
    [OutPortTypes("string")]
    [OutPortDescriptions("Результат")]
    [Export(typeof(NodeModel))]
    public class SimpleTestNode : NodeModel
    {
        public SimpleTestNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private SimpleTestNode(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("Simple Test Node Works!"))
            };
        }
    }
}