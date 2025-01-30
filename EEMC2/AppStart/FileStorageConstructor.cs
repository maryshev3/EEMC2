using EEMC2.AppStart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.AppStart
{
    public class FileStorageConstructor
    {
        private static string GetMyDocumentsPath() =>
            Environment.GetFolderPath(
                Environment
                    .SpecialFolder
                    .MyDocuments
            );

        private static string GetApplicationInMyDocumentsPath(string myDocumentsPath) =>
            Path.Combine(myDocumentsPath, "EEMC2");

        private static string GetRepositoryFilesDirectory(string applicationInMyDocumentsPath) =>
            Path.Combine(
                applicationInMyDocumentsPath,
                "RepositoryStorage"
            );

        private static string GetImagesDirectory(string applicationInMyDocumentsPath) =>
            Path.Combine(
                applicationInMyDocumentsPath,
                "Images"
            );

        private static void EnsureDirectoryExists(string directoryPath) =>
            Directory.CreateDirectory(directoryPath);

        public FileStorageConstructorResult Construct()
        {
            string applicationInMyDocumentsPath = GetApplicationInMyDocumentsPath(GetMyDocumentsPath());

            string repositoryFilesDirectory = GetRepositoryFilesDirectory(applicationInMyDocumentsPath);
            var imagesDirectory = GetImagesDirectory(applicationInMyDocumentsPath);

            EnsureDirectoryExists(repositoryFilesDirectory);
            EnsureDirectoryExists(imagesDirectory);

            return new FileStorageConstructorResult()
            {
                RepositoryFilesPath = repositoryFilesDirectory,
                ImagesPath = imagesDirectory
            };
        }
    }
}
