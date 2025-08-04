using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject
{
    public static class Delete
    {
        public static bool DeleteByObj(PDataObject @object)
        {
            return DeleteById(@object.Id);
        }

        public static bool DeleteById(Guid objectId)
        {
            try
            {
                StaticMetadata.ObjectModifier.DeleteById(objectId);
                StaticMetadata.ObjectModifier.Apply();
                StaticMetadata.ObjectModifier.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeletePermanently(Guid objectId)
        {
            try
            {
                StaticMetadata.ObjectModifier.DeletePermanently(objectId);
                StaticMetadata.ObjectModifier.Apply();
                StaticMetadata.ObjectModifier.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
