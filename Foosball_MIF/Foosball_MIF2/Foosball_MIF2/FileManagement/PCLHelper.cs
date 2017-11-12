using PCLStorage;
using System;
using System.Threading.Tasks;

namespace Foosball_MIF2.FileManagement
{
    public static class PCLHelper
    {

        public async static Task<bool> IsFileExistAsync(string fileName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            // get hold of the file system  
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);
            // already run at least once, don't overwrite what's there  
            if (folderexist == ExistenceCheckResult.FileExists)
            {
                return true;
            }
            return false;
        }

        public async static Task<bool> IsFolderExistAsync(string folderName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            ExistenceCheckResult folderexist = await folder.CheckExistsAsync(folderName);
            if (folderexist == ExistenceCheckResult.FolderExists)
            {
                return true;

            }
            return false;
        }

        public async static Task<IFolder> CreateFolder(string folderName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);
            return folder;
        }

        public async static Task<IFile> CreateFile(string filename, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            return file;
        }
        public async static Task<bool> WriteTextAllAsync(string filename, string content = "", IFolder rootFolder = null)
        {
            IFile file = await CreateFile(filename,rootFolder);
            await file.WriteAllTextAsync(content);
            return true;
        }

        public async static Task<string> ReadAllTextAsync(string fileName, IFolder rootFolder = null)
        {
            string content = "";
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            bool exist = await IsFileExistAsync(fileName, folder);
            if (exist == true)
            {
                IFile file = await folder.GetFileAsync(fileName);
                content = await file.ReadAllTextAsync();
            }
            return content;
        }
        public async static Task<bool> DeleteFile(string fileName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            bool exist = await IsFileExistAsync(fileName,folder);
            if (exist == true)
            {
                IFile file = await folder.GetFileAsync(fileName);
                await file.DeleteAsync();
                return true;
            }
            return false;
        }
        public async static Task SaveImage(byte[] image, String fileName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;
            // create a file, overwriting any existing file  
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            // populate the file with image data  
            using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                stream.Write(image, 0, image.Length);
            }
        }

        public async static Task<byte[]> LoadImage(byte[] image, String fileName, IFolder rootFolder = null)
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder folder = rootFolder ?? fileSystem.LocalStorage;

            //open file if exists  
            IFile file = await folder.GetFileAsync(fileName);
            //load stream to buffer  
            using (System.IO.Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                long length = stream.Length;
                byte[] streamBuffer = new byte[length];
                stream.Read(streamBuffer, 0, (int)length);
                return streamBuffer;
            }

        }
    }
}
