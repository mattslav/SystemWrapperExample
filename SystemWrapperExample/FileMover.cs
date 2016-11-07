using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemWrapperExample
{
    public class FileMover
    {
        public void Move(string filePath, string destinationDirectory)
        {
            Directory.CreateDirectory(destinationDirectory);

            var newFilePath = $@"{destinationDirectory}\{Path.GetFileName(filePath)}";

            File.Move(filePath, newFilePath);
        }
    }
}
