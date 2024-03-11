using System.IO;

namespace Sniffer.Lib.Models;

public interface IFile
{
    public StreamWriter Writer { get; }
    public StreamReader Reader { get; }
}