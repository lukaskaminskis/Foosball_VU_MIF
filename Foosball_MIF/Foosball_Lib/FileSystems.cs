using System;
using System.Threading.Tasks;
using PCLStorage;

namespace Foosball_Lib
{
    public static class FileSystems
    {
		public async static Task Party()
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
				CreationCollisionOption.OpenIfExists);
			IFile file = await folder.CreateFileAsync("answer.txt",
				CreationCollisionOption.ReplaceExisting);
			await file.WriteAllTextAsync("42");
		}

		public async static Task<bool> IsFileExistAsync(this string fileName, IFolder rootFolder = null)
		{
			// get hold of the file system  
			IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
			ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);
			// already run at least once, don't overwrite what's there  
			if (folderexist == ExistenceCheckResult.FileExists)
			{
				return true;

			}
			return false;
		}

		public async static Task<IFile> CreateFile(this string filename, IFolder rootFolder = null)
		{
			IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
			IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
			return file;
		}

		public async static Task<bool> WriteTextAllAsync(this string filename, string content = "", IFolder rootFolder = null)
		{
			IFile file = await filename.CreateFile(rootFolder);
			await file.WriteAllTextAsync(content);
			return true;
		}

		public async static Task<string> ReadAllTextAsync(this string fileName, IFolder rootFolder = null)
		{
			string content = "";
			IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
			bool exist = await fileName.IsFileExistAsync(folder);
			if (exist == true)
			{
				IFile file = await folder.GetFileAsync(fileName);
				content = await file.ReadAllTextAsync();
			}
			return content;
		}


	}
}
