using System;
using System.IO;

namespace DynamoPilot.App.Configuration
{
    internal static class PackageDeployer
    {
        /// <summary>
        /// Копирует содержимое папки pkgsDir в %APPDATA%\Dynamo\Dynamo Core\2.16\packages.
        /// Файлы с теми же именами перезаписываются.
        /// </summary>
        public static void CopyPackageFolder(string pkgsDir)
        {
            //if (!Directory.Exists(pkgsDir)) return;   // нечего копировать

            // C:\Users\<user>\AppData\Roaming
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var targetRoot = Path.Combine(appData, @"Dynamo\Dynamo Core\2.16\packages");

            CopyDirectory(pkgsDir, targetRoot);
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            // создаём целевую папку, если её ещё нет
            Directory.CreateDirectory(targetDir);

            // копируем все файлы
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var dest = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, dest, overwrite: true);
            }

            // рекурсивно копируем подкаталоги
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                var destSub = Path.Combine(targetDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSub);
            }
        }
    }
}
