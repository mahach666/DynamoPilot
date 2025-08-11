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

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject CreateFileSnapshotByObj(PDataObject obj, string reason)
        {
            return CreateFileSnapshot(obj.Id, reason);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSnapshotActual(Guid objectId,
           string reason,
           PFilesSnapshot snapshot)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSnapshotActual(reason, (IFilesSnapshot)snapshot.Unwrap());

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSnapshotActualByObj(PDataObject obj,
           string reason,
           PFilesSnapshot snapshot)
        {
            return MakeSnapshotActual(obj.Id, reason, snapshot);
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

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject ReplaceFileInSnapshotByObj(PDataObject obj,
            DateTime snapshotCreated,
            Guid fileToReplace,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            return ReplaceFileInSnapshot(obj.Id,
                snapshotCreated,
                fileToReplace,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime);
        }
    }
}
