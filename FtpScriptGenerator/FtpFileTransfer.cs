using System.IO;
using System.Linq;

namespace FtpScriptGenerator
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
                    batchFile.WriteLine("cd " + args.SourceRootDir + @"\" + dir.Name);

                    var script = new FtpScript
                    {
                        DestinationRootDirectory = args.DestinationRootDir + @"\" + dir.Name,
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
}
