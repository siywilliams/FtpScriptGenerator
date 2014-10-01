using System.Collections.Generic;
using System.Linq;

namespace FtpScriptGenerator
{
    public class FileSorter
    {
        private readonly FileParser _fileParser;

        public FileSorter(FileParser fileParser)
        {
            _fileParser = fileParser;
        }

        public IEnumerable<FtpDirectory> Sort(IEnumerable<string> paths)
        {
            var directories = new List<FtpDirectory>();

            foreach (var path in paths)
            {
                var info = _fileParser.Parse(path);
                var existing = directories.FirstOrDefault(dir => dir.Path == info.Directory);
                if (existing != null)
                {
                    existing.AddFile(info);
                }
                else
                {
                    var ftpDir = new FtpDirectory(info.Directory);
                    ftpDir.AddFile(info);
                    directories.Add(ftpDir);
                }
            }

            return directories;
        }
    }
}