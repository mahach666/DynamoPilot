using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.IO;

namespace FileProvider
{
    /// <summary>
    /// Ноды-методы для работы с провайдером файлов Pilot
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Удаляет локальную копию файла по его идентификатору
        /// </summary>
        /// <param name="pFileProvider">Провайдер файлов</param>
        /// <param name="fileId">Идентификатор файла</param>
        [IsDesignScriptCompatible]
        public static void DeleteLocalFile(PFileProvider pFileProvider, Guid fileId)
        {
            pFileProvider.DeleteLocalFile(fileId);
        }

        /// <summary>
        /// Проверяет наличие локальной копии файла
        /// </summary>
        /// <param name="pFileProvider">Провайдер файлов</param>
        /// <param name="fileId">Идентификатор файла</param>
        /// <returns>True, если локальная копия существует</returns>
        [IsDesignScriptCompatible]
        public static bool Exists(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.Exists(fileId);
        }

        /// <summary>
        /// Возвращает размер локальной копии файла на диске
        /// </summary>
        /// <param name="pFileProvider">Провайдер файлов</param>
        /// <param name="fileId">Идентификатор файла</param>
        /// <returns>Размер файла в байтах</returns>
        [IsDesignScriptCompatible]
        public static long GetFileSizeOnDisk(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.GetFileSizeOnDisk(fileId);
        }

        /// <summary>
        /// Проверяет, полностью ли загружен файл
        /// </summary>
        /// <param name="pFileProvider">Провайдер файлов</param>
        /// <param name="fileId">Идентификатор файла</param>
        /// <returns>True, если файл загружен полностью</returns>
        [IsDesignScriptCompatible]
        public static bool IsFull(PFileProvider pFileProvider, Guid fileId)
        {
            return pFileProvider.IsFull(fileId);
        }

        /// <summary>
        /// Открывает поток для чтения содержимого файла
        /// </summary>
        /// <param name="pFileProvider">Провайдер файлов</param>
        /// <param name="file">Файл</param>
        /// <returns>Поток для чтения</returns>
        [IsDesignScriptCompatible]
        public static Stream OpenRead(PFileProvider pFileProvider, PFile file)
        {
            return pFileProvider.OpenRead((IFile)file.Unwrap());
        }
    }
}
