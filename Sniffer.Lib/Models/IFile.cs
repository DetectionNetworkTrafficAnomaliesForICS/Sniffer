using System.IO;

namespace Sniffer.Lib.Models;

public interface IFile
{
    StreamWriter Writer { get; }
    StreamReader Reader { get; }
}