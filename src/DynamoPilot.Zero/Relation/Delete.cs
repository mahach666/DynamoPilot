using Ascon.Pilot.SDK;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace Relation
{
    public static class Delete
    {
        public static bool RemoveLink(PDataObject obj, PRelation relation)
        {
            try
            {
                StaticMetadata.ObjectModifier.RemoveLink((IDataObject)obj.Unwrap(), (IRelation)relation.Unwrap());
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
