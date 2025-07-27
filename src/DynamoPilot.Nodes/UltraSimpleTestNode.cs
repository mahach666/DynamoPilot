using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Ultra Simple Test")]
    [NodeCategory("Pilot.Test")]
    [NodeDescription("Очень простая тестовая нода")]
    [IsDesignScriptCompatible]
    [OutPortNames("result")]
    [OutPortTypes("string")]
    [OutPortDescriptions("Результат")]
    [Export(typeof(NodeModel))]
    public class UltraSimpleTestNode : NodeModel
    {
        public UltraSimpleTestNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private UltraSimpleTestNode(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("Ultra Simple Test Node Works!"))
            };
        }
    }
}