using System.IO;

namespace Sniffer.Lib.Models;

public interface IFile
{
    string Path { get; }
    StreamWriter Writer { get; }
    StreamReader Reader { get; }
}