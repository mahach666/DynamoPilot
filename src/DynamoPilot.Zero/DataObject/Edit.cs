using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.IO;

namespace DataObject
{
    public static class Edit
    {
        [IsDesignScriptCompatible]
        public static PDataObject ChangeState(PDataObject @object, ObjectState state)
        {
            StaticMetadata.ObjectModifier.ChangeState((IDataObject)@object.Unwrap(), state);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(@object.Id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject Restore(Guid objectId, Guid parentId)
        {
            StaticMetadata.ObjectModifier.Restore(objectId, parentId);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RestorePermanentlyDeletedObject(Guid id, Guid parentId, IType type)
        {
            StaticMetadata.ObjectModifier.RestorePermanentlyDeletedObject(id, parentId, type);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(id);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecords(Guid objectId,
           int orgUnitId,
           AccessLevel level,
           DateTime validThrough,
           AccessInheritance inheritance,
           AccessType type)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddAccessRecords(Guid objectId,
            int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type,
            int[] typeIds)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type,
                typeIds);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFile(Guid objectId, string path)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFile(path);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFile(Guid objectId,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFile(name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFile(Guid objectId,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime,
            out Guid fileId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFile(name,
                stream, creationTime,
                lastAccessTime,
                lastWriteTime,
                out fileId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFileInSnapshot(Guid objectId,
            DateTime snapshotCreated,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime,
            out Guid fileId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFileInSnapshot(snapshotCreated,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime,
                out fileId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddOrReplaceFile(Guid objectId,
            string name,
            Stream stream,
            IFile file,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddOrReplaceFile(name,
                stream,
                file,
                creationTime,
                lastAccessTime,
                lastWriteTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddRelation(Guid objectId,
            string name,
            ObjectRelationType type,
            Guid sourceId,
            Guid targetId,
            DateTime versionId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddRelation(name,
                type,
                sourceId,
                targetId,
                versionId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddSubscriber(Guid objectId,
            int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddSubscriber(personId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject CreateFileSnapshot(Guid objectId, string reason)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).CreateFileSnapshot(reason);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject Lock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Lock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakePublic(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakePublic();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSecret(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSecret();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject MakeSnapshotActual(Guid objectId,
            string reason,
            IFilesSnapshot snapshot)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSnapshotActual(reason, snapshot);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        //[IsDesignScriptCompatible]
        //public static PDataObject RemoveAccessRecords(Func<IAccessRecord, bool> predicate)
        //{
        //    _objectBuilder.RemoveAccessRecords(predicate);
        //    return this;
        //}

        [IsDesignScriptCompatible]
        public static PDataObject RemoveAttribute(Guid objectId, string name)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).RemoveAttribute(name);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject RemoveSubscriber(Guid objectId, int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).RemoveSubscriber(personId);

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

        [IsDesignScriptCompatible]
        public static PDataObject SaveHistoryItem(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SaveHistoryItem();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            string value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            int value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            double value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            DateTime value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            decimal value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            long value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            Guid value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            int[] value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttribute(Guid objectId,
            string name,
            string[] value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetAttributeAsObject(Guid objectId,
            string name,
            object value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttributeAsObject(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetCreationDate(Guid objectId, DateTime dateTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreationDate(dateTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetCreator(Guid objectId,
            int creatorId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetCreator(creatorId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIsDeleted(Guid objectId,
            bool isDeleted)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsDeleted(isDeleted);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIsInRecycleBin(Guid objectId,
            bool isInRecycleBin)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsInRecycleBin(isInRecycleBin);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetParent(Guid objectId, Guid parentId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetParent(parentId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        //[IsDesignScriptCompatible]
        //public PSignatureModifier SetSignatures(Predicate<IFile> selectFilesPredicate)
        //{
        //    return new(_objectBuilder.SetSignatures(selectFilesPredicate));
        //}

        [IsDesignScriptCompatible]
        public static PDataObject SetType(Guid objectId, IType type)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetType(type);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject Unlock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Unlock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }
    }
}
