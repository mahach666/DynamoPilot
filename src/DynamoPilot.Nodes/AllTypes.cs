//using CoreNodeModels;
//using Dynamo.Graph.Nodes;
//using Newtonsoft.Json;
//using ProtoCore.AST.AssociativeAST;
//using System.Collections.Generic;

//namespace DynamoPilot.Nodes
//{
//    [NodeName("Object Type")]
//    [NodeCategory("Pilot.Data")]
//    [NodeDescription("Выбрать тип из репозитория Pilot")]
//    [IsDesignScriptCompatible]
//    [OutPortNames("type")]
//    [OutPortTypes("string")]
//    [OutPortDescriptions("Выбранный ObjectType")]
//    public class AllTypes : DSDropDownBase
//    {
//        // ---------- конструктора два: для нового узла и для загрузки из .dyn ----------
//        public AllTypes() : base("Тип") { }

//        [JsonConstructor]                       // обязателен для Dynamo 2.x+
//        public AllTypes(IEnumerable<PortModel> inPorts,
//                           IEnumerable<PortModel> outPorts) : base("Тип") { }

//        // ---------- наполняем список --------------------------------------------------
//        protected override SelectionState PopulateItemsCore(string currentSelection)
//        {
//            //Items.Clear();

//            //if (StaticMetadata.ObjectsRepository == null)
//            //{
//            //    Items.Add(new DynamoDropDownItem("репозиторий не задан", null));
//            //    SelectedIndex = 0;
//            //    return SelectionState.Restore;
//            //}

//            //var types = StaticMetadata.ObjectsRepository.GetTypes().OrderBy(t => t.Name).ToList();
//            //foreach (var t in types)
//            //    Items.Add(new DynamoDropDownItem(t.Name, t));

//            //SelectedIndex = Math.Max(0, Math.Min(SelectedIndex, Items.Count - 1));
//            //return SelectionState.Done;
//            return SelectionState.Restore; // не меняем состояние, т.к. список уже заполнен
//        }

//        // ---------- что нода отдаёт на выход -----------------------------------------
//        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
//        {
////            // ничего не выбрано → null
////            if (SelectedIndex < 0 || SelectedIndex >= Items.Count ||
////                Items[SelectedIndex].Item == null)
////            {
////                return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0),
////                                                          AstFactory.BuildNullNode()) };
////            }

////            // возвращаем сам ObjectType (Dynamo передаст .NET‑объект дальше по графу)
////            //var objectType = Items[SelectedIndex].Item;

////            var typeName = Items[SelectedIndex].Name;

////            return new[]
////            {
////AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0),
////                                           AstFactory.BuildStringNode(typeName))
////            };
//return new[]
//            {
//                AstFactory.BuildAssignment(
//                    GetAstIdentifierForOutputIndex(0),
//                    AstFactory.BuildStringNode(SelectedIndex >= 0 && SelectedIndex < Items.Count
//                        ? Items[SelectedIndex].Name
//                        : string.Empty))
//            };
//        }
//    }
//}
