using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemInterface.IO;

namespace SystemWrapperExample
{
    public class FileMoverWithWrappers
    {
        private readonly IDirectory _directory;
        private readonly IPath _path;
        private readonly IFile _file;

        public FileMoverWithWrappers(IDirectory directory, IPath path, IFile file)
        {
            _directory = directory;
            _path = path;
            _file = file;
        }

        public void Move(string filePath, string destinationDirectory)
        {
            _directory.CreateDirectory(destinationDirectory);

            var newFilePath = $@"{destinationDirectory}\{_path.GetFileName(filePath)}";

            _file.Move(filePath, newFilePath);
        }
    }
}
