using System;
using System.Threading.Tasks;

namespace Foosball_Lib.FileManagement
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string name, string text);
    }
}
