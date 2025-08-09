using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.IO;

namespace DataObject.Edit
{
    public class Snapshot
    {
        [IsDesignScriptCompatible]
        public static PDataObject CreateFileSnapshot(Guid objectId, string reason)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).CreateFileSnapshot(reason);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSnapshotActual(Guid objectId,
           string reason,
           PFilesSnapshot snapshot)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSnapshotActual(reason, (IFilesSnapshot)snapshot.Unwrap());

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }


        [IsDesignScriptCompatible]
        public static PDataObject ReplaceFileInSnapshot(Guid objectId,
            DateTime snapshotCreated,
            Guid fileToReplace,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).ReplaceFileInSnapshot(snapshotCreated,
                fileToReplace,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }
    }
}
