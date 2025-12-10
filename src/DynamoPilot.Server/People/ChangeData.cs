using System;
using System.Collections.Generic;
using System.Linq;
using Ascon.Pilot.DataClasses;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace ServerPeople
{
    /// <summary>
    /// Узлы для формирования данных изменений пользователя.
    /// </summary>
    [NodeCategory("Pilot.Server.People")]
    [NodeDescription("Формирование DPersonChangeData и DPersonChangeset")]
    public static class ChangeData
    {
        [NodeName("CreatePersonChangeData")]
        [IsDesignScriptCompatible]
        public static DPersonChangeData CreatePersonChangeData(DPerson oldPerson, DPerson newPerson, string newPasswordEncrypted = null)
        {
            if (oldPerson == null)
                throw new ArgumentNullException(nameof(oldPerson));
            if (newPerson == null)
                throw new ArgumentNullException(nameof(newPerson));

            if (string.IsNullOrWhiteSpace(newPasswordEncrypted))
                return new DPersonChangeData(oldPerson, newPerson);

            return new DPersonChangeData(oldPerson, newPerson, newPasswordEncrypted);
        }

        [NodeName("CreatePersonChangeset")]
        [IsDesignScriptCompatible]
        public static DPersonChangeset CreatePersonChangeset(IList<DPersonChangeData> changes)
        {
            var array = changes?.ToArray() ?? Array.Empty<DPersonChangeData>();
            return new DPersonChangeset(array);
        }
    }
}
