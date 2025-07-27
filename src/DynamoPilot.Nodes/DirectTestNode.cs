using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{
    [NodeName("Direct Test")]
    [NodeCategory("Pilot.Test")]
    [NodeDescription("Прямая тестовая нода без MEF")]
    [IsDesignScriptCompatible]
    [OutPortNames("result")]
    [OutPortTypes("string")]
    [OutPortDescriptions("Результат")]
    public class DirectTestNode : NodeModel
    {
        public DirectTestNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private DirectTestNode(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("Direct Test Node Works!"))
            };
        }
    }
}