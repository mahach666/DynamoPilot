using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;

namespace DynamoPilot.Nodes
{
    [NodeName("Pilot Info")]
    [NodeCategory("Pilot.Data")]
    [NodeDescription("Получает информацию о репозитории Pilot")]
    [IsDesignScriptCompatible]
    [OutPortNames("isConnected", "typeCount", "repositoryName", "status")]
    [OutPortTypes("bool", "double", "string", "string")]
    [OutPortDescriptions("Подключен ли репозиторий", "Количество типов", "Имя репозитория", "Статус")]
    [Export(typeof(NodeModel))]
    public class PilotInfoNode : NodeModel
    {
        public PilotInfoNode()
        {
            RegisterAllPorts();
        }

        [JsonConstructor]
        private PilotInfoNode(IEnumerable<PortModel> inPorts,
                             IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
        {
            bool isConnected = false;
            int typeCount = 0;
            string repositoryName = "Не подключен";
            string status = "Ошибка";

            if (StaticMetadata.ObjectsRepository != null)
            {
                try
                {
                    isConnected = true;
                    var types = StaticMetadata.ObjectsRepository.GetTypes();
                    typeCount = types.Count();
                    repositoryName = "Pilot Repository";
                    status = "OK";
                }
                catch
                {
                    isConnected = false;
                    typeCount = -1;
                    repositoryName = "Ошибка подключения";
                    status = "Ошибка";
                }
            }

            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildBooleanNode(isConnected)),
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(1),
                    AstFactory.BuildDoubleNode(typeCount)),
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(2),
                    AstFactory.BuildStringNode(repositoryName)),
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(3),
                    AstFactory.BuildStringNode(status))
            };
        }
    }
}