using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerPeople
{
    /// <summary>
    /// Узлы для сборки изменений пользователей (DPersonChangeset).
    /// </summary>
    [NodeCategory("Pilot.Server.People.Change")]
    [NodeDescription("Конструкторы изменений пользователей")]
    public static class ChangeData
    {
        [NodeName("MakeChangeData")]
        [IsDesignScriptCompatible]
        public static DPersonChangeData MakeChangeData(DPerson oldPerson, DPerson newPerson, string encryptedPassword = null)
        {
            if (!string.IsNullOrEmpty(encryptedPassword))
                return new DPersonChangeData(oldPerson, newPerson, encryptedPassword);
            return new DPersonChangeData(oldPerson, newPerson);
        }

        [NodeName("MakeChangeset")]
        [IsDesignScriptCompatible]
        public static DPersonChangeset MakeChangeset(IList<DPersonChangeData> changes)
        {
            return changes == null
                ? new DPersonChangeset()
                : new DPersonChangeset(changes.ToArray());
        }
    }
}

