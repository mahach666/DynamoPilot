using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.IO;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для работы с файлами объектов данных в системе Pilot
    /// </summary>
    public static class File
    {
        /// <summary>
        /// Добавляет файл к объекту по пути
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddFileByPath(Guid objectId, string path)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFile(path);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Добавляет файл к объекту по пути
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddFileByObjAndPath(PDataObject obj, string path)
        {
            return AddFileByPath(obj.Id, path);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFileByStream(Guid objectId,
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
        public static PDataObject AddFileByObjAndStream(
            PDataObject obj,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            return AddFileByStream(obj.Id,
                        name,
                        stream,
                        creationTime,
                        lastAccessTime,
                        lastWriteTime);
        }

        //[IsDesignScriptCompatible]
        //public static PDataObject AddFile(Guid objectId,
        //    string name,
        //    Stream stream,
        //    DateTime creationTime,
        //    DateTime lastAccessTime,
        //    DateTime lastWriteTime,
        //    out Guid fileId)
        //{
        //    StaticMetadata.ObjectModifier.EditById(objectId).AddFile(name,
        //        stream, creationTime,
        //        lastAccessTime,
        //        lastWriteTime,
        //        out fileId);

        //    StaticMetadata.ObjectModifier.Apply();
        //    StaticMetadata.ObjectModifier.Clear();

        //    return Select.GetByGuid(objectId);
        //}

        [IsDesignScriptCompatible]
        public static PDataObject AddFileInSnapshot(Guid objectId,
            DateTime snapshotCreated,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddFileInSnapshot(snapshotCreated,
                name,
                stream,
                creationTime,
                lastAccessTime,
                lastWriteTime,
                out Guid fileId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddFileInSnapshotByObj(
            PDataObject obj,
            DateTime snapshotCreated,
            string name,
            Stream stream,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            return AddFileInSnapshot(obj.Id,
                          snapshotCreated,
                          name,
                          stream,
                          creationTime,
                          lastAccessTime,
                          lastWriteTime);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddOrReplaceFile(Guid objectId,
            string name,
            Stream stream,
            PFile file,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddOrReplaceFile(name,
                stream,
                (IFile)file.Unwrap(),
                creationTime,
                lastAccessTime,
                lastWriteTime);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject AddOrReplaceFileByObj(
            PDataObject obj,
            string name,
            Stream stream,
            PFile file,
            DateTime creationTime,
            DateTime lastAccessTime,
            DateTime lastWriteTime)
        {
            return AddOrReplaceFile(obj.Id,
                                    name,
                                    stream,
                                    file,
                                    creationTime,
                                    lastAccessTime,
                                    lastWriteTime);
        }
    }
}
