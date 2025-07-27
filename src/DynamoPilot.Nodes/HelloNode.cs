using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{

    [NodeName("Hello World")]
    [NodeCategory("Pilot.Test")]
    [NodeDescription("Возвращает строку «Привет мир!»")]
    [IsDesignScriptCompatible]

    [OutPortNames("text")]
    [OutPortTypes("string")]
    [OutPortDescriptions("Привет мир!")]

    public class HelloNode : NodeModel
    {
        /* ---------- новый узел ---------- */
        public HelloNode()
        {
            //OutPortData.Add(new PortData("text", "Привет мир!"));
            RegisterAllPorts();               // обязательный вызов
        }

        /* ---------- загрузка из .dyn ---------- */
        [JsonConstructor]
        private HelloNode(IEnumerable<PortModel> inPorts,
                          IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        /* ---------- BuildOutputAst ---------- */
        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("Привет мир!"))
            };
        }
    }
}
