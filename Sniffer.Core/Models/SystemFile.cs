using System.IO;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class SystemFile(string name) : IFile
{
    public StreamWriter Writer => new(name);
    public StreamReader Reader => new(name);
}