using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.IO;

namespace DynamoPilot.Data.Wrappers
{
    public class PObjectBuilder : IWrapper
    {
        private readonly IObjectBuilder _objectBuilder;
        public PObjectBuilder(IObjectBuilder objectBuilder)
        {
            _objectBuilder = objectBuilder;
        }

        public PDataObject DataObject => new(_objectBuilder.DataObject);

        public PObjectBuilder AddAccessRecords(int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type)
        {
            _objectBuilder.AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type);
            return this;
        }

        public PObjectBuilder AddAccessRecords(int orgUnitId,
            AccessLevel level,
            DateTime validThrough,
            AccessInheritance inheritance,
            AccessType type,
            int[] typeIds)
        {
            _objectBuilder.AddAccessRecords(orgUnitId,
                level,
                validThrough,
                inheritance,
                type,
                typeIds);
            return this;
        }

        public PObjectBuilder AddFile(string path)
        {
            _objectBuilder.AddFile(path);
            return this;
        }

        public PObjectBuilder AddFile(string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            _objectBuilder.AddFile(name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime);
            return this;
        }

        public PObjectBuilder AddFile(string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime,
            out Guid fileId)
        {
            _objectBuilder.AddFile(name,
                stream, creationTime,
                lastAccessTime,
                lastWriteTime,
                out fileId);
            return this;
        }

        public PObjectBuilder AddFileInSnapshot(DateTime snapshotCreated,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime,
            out Guid fileId)
        {
            _objectBuilder.AddFileInSnapshot(snapshotCreated,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime,
                out fileId);
            return this;
        }

        public PObjectBuilder AddOrReplaceFile(string name,
            Stream stream,
            IFile file,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            _objectBuilder.AddOrReplaceFile(name,
                stream,
                file,
                creationTime,
                lastAccessTime,
                lastWriteTime);
            return this;
        }

        public PObjectBuilder AddRelation(string name,
            ObjectRelationType type,
            Guid sourceId,
            Guid targetId,
            DateTime versionId)
        {
            _objectBuilder.AddRelation(name,
                type,
                sourceId,
                targetId,
                versionId);
            return this;
        }

        //public PObjectBuilder AddSourceFileRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.AddSourceFileRelation(relatedObjectId);
        //    return this;
        //}

        public PObjectBuilder AddSubscriber(int personId)
        {
            _objectBuilder.AddSubscriber(personId);
            return this;
        }

        //public PObjectBuilder AddTaskInitiatorAttachmentRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.AddTaskInitiatorAttachmentRelation(relatedObjectId);
        //    return this;
        //}

        //public PObjectBuilder AddTaskMessageAttachmentRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.AddTaskMessageAttachmentRelation(relatedObjectId);
        //    return this;
        //}

        public PObjectBuilder CreateFileSnapshot(string reason)
        {
            _objectBuilder.CreateFileSnapshot(reason);
            return this;
        }

        public PObjectBuilder Lock()
        {
            _objectBuilder.Lock();
            return this;
        }

        public PObjectBuilder MakePublic()
        {
            _objectBuilder.MakePublic();
            return this;
        }

        public PObjectBuilder MakeSecret()
        {
            _objectBuilder.MakeSecret();
            return this;
        }

        public PObjectBuilder MakeSnapshotActual(string reason, IFilesSnapshot snapshot)
        {
            _objectBuilder.MakeSnapshotActual(reason, snapshot);
            return this;
        }

        public PObjectBuilder RemoveAccessRecords(Func<IAccessRecord, bool> predicate)
        {
            _objectBuilder.RemoveAccessRecords(predicate);
            return this;
        }

        //public PObjectBuilder RemoveAccessRights(int positionId)
        //{
        //    _objectBuilder.RemoveAccessRights(positionId);
        //    return this;
        //}

        public PObjectBuilder RemoveAttribute(string name)
        {
            _objectBuilder.RemoveAttribute(name);
            return this;
        }

        //public PObjectBuilder RemoveSourceFileRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.RemoveSourceFileRelation(relatedObjectId);
        //    return this;
        //}

        public PObjectBuilder RemoveSubscriber(int personId)
        {
            _objectBuilder.RemoveSubscriber(personId);
            return this;
        }

        //public PObjectBuilder RemoveTaskInitiatorAttachmentRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.RemoveTaskInitiatorAttachmentRelation(relatedObjectId);
        //    return this;
        //}

        //public PObjectBuilder RemoveTaskMessageAttachmentRelation(Guid relatedObjectId)
        //{
        //    _objectBuilder.RemoveTaskMessageAttachmentRelation(relatedObjectId);
        //    return this;
        //}

        public PObjectBuilder ReplaceFileInSnapshot(DateTime snapshotCreated,
            Guid fileToReplace,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            _objectBuilder.ReplaceFileInSnapshot(snapshotCreated,
                fileToReplace,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime);
            return this;
        }

        public PObjectBuilder SaveHistoryItem()
        {
            _objectBuilder.SaveHistoryItem();
            return this;
        }

        //public PObjectBuilder SetAccessRights(int positionId, AccessLevel level, DateTime validThrough, bool isInheritable)
        //{
        //    _objectBuilder.SetAccessRights(positionId, level, validThrough, isInheritable);
        //    return this;
        //}

        public PObjectBuilder SetAttribute(string name, string value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, int value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, double value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, DateTime value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, decimal value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, long value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, Guid value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, int[] value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttribute(string name, string[] value)
        {
            _objectBuilder.SetAttribute(name, value);
            return this;
        }

        public PObjectBuilder SetAttributeAsObject(string name, object value)
        {
            _objectBuilder.SetAttributeAsObject(name, value);
            return this;
        }

        public PObjectBuilder SetCreationDate(DateTime dateTime)
        {
            _objectBuilder.SetCreationDate(dateTime);
            return this;
        }

        public PObjectBuilder SetCreator(int creatorId)
        {
            _objectBuilder.SetCreator(creatorId);
            return this;
        }

        public PObjectBuilder SetIsDeleted(bool isDeleted)
        {
            _objectBuilder.SetIsDeleted(isDeleted);
            return this;
        }

        public PObjectBuilder SetIsInRecycleBin(bool isInRecycleBin)
        {
            _objectBuilder.SetIsInRecycleBin(isInRecycleBin);
            return this;
        }

        public PObjectBuilder SetParent(Guid parentId)
        {
            _objectBuilder.SetParent(parentId);
            return this;
        }

        public PSignatureModifier SetSignatures(Predicate<IFile> selectFilesPredicate)
        {
            return new(_objectBuilder.SetSignatures(selectFilesPredicate));
        }

        public PObjectBuilder SetType(IType type)
        {
            _objectBuilder.SetType(type);
            return this;
        }

        public PObjectBuilder Unlock()
        {
            _objectBuilder.Unlock();
            return this;
        }

        public object Unwrap()
        {
            return _objectBuilder;
        }
    }
}
