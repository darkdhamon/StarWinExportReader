using System.IO;

namespace ConverterTools
{
    public class FileReader
    {
        public string[] Lines { get; set; }

        public void ReadFile(string fileURI)
        {
            Lines = File.ReadAllLines(fileURI);
        }
    }
}