using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FtpFileTransfer
{
    public class FtpFileTransfer
    {
        public void Execute(Arguments args)
        {
            var sortedFiles = new FileSorter(new FileParser()).Sort(args.Files);

            using (var batchFile = File.CreateText(args.OutputDir + @"\run-all.bat"))
            {
                foreach (var dir in sortedFiles)
                {
                    var script = new FtpScript
                    {
                        DestinationRootDirectory = args.DestinationRootDir + @"\" + dir.Name,
                        SourceRootDirectory = args.SourceRootDir + @"\" + dir.Name,
                        FilePath = args.OutputDir + @"\" + dir.Name + ".script",
                        Files = dir.Select(file => file.Filename).ToList(),
                        Host = args.Host,
                        Username = args.Username,
                        Password = args.Password
                    };

                    batchFile.WriteLine("ftp -s:" + script.FilePath);

                    script.Write();
                }
            }
        }
    }

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
