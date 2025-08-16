using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace Relation
{
    /// <summary>
    /// Ноды для удаления связей между объектами в системе Pilot
    /// </summary>
    public static class Delete
    {
        /// <summary>
        /// Удаляет связь между объектом и связью
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="relation">Связь для удаления</param>
        /// <returns>True, если удаление прошло успешно</returns>
        [IsDesignScriptCompatible]
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
