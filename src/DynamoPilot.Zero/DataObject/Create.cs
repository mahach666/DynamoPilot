using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject
{
    public static class Create
    {
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentObjAndType(PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(builder.DataObject.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentObjAndType(Guid id, PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(id, (IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(builder.DataObject.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentIdAndType(Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(builder.DataObject.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentIdAndType(Guid id, Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(builder.DataObject.Id);
        }
    }
}
