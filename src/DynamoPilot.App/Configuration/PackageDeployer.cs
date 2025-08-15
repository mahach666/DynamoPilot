using System;
using System.IO;

namespace DynamoPilot.App.Configuration
{
    internal static class PackageDeployer
    {
        private static bool _packagesCopied = false;

        /// <summary>
        /// Копирует содержимое папки pkgsDir в %APPDATA%\Dynamo\Dynamo Core\2.16\packages.
        /// Файлы с теми же именами перезаписываются. Копирование происходит только один раз за сессию приложения.
        /// </summary>
        public static void CopyPackageFolder(string pkgsDir)
        {
            if (_packagesCopied)
                return;

            if (!Directory.Exists(pkgsDir)) 
                return;   

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var targetRoot = Path.Combine(appData, @"Dynamo\Dynamo Core\2.16\packages");

            try
            {
                CopyDirectory(pkgsDir, targetRoot);
                _packagesCopied = true;
            }
            catch (IOException ex) when (ex.Message.Contains("используется другим процессом"))
            {
                _packagesCopied = true;
            }
        }

        /// <summary>
        /// Сбрасывает флаг копирования пакетов. Используется для принудительного повторного копирования.
        /// </summary>
        public static void ResetPackagesCopiedFlag()
        {
            _packagesCopied = false;
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var dest = Path.Combine(targetDir, Path.GetFileName(file));
                try
                {
                    File.Copy(file, dest, overwrite: true);
                }
                catch (IOException ex) when (ex.Message.Contains("используется другим процессом"))
                {
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }

            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                var destSub = Path.Combine(targetDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSub);
            }
        }
    }
}
