using System.Collections.Generic;
using System.IO;

namespace FtpFileTransfer
{
    public class FtpScript
    {
        public string FilePath { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DestinationRootDirectory { get; set; }
        public string SourceRootDirectory { get; set; }
        public IEnumerable<string> Files { get; set; }

        public void Write()
        {
            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("cd " + SourceRootDirectory);
                writer.WriteLine("Open " + Host);
                writer.WriteLine(Username);
                writer.WriteLine(Password);
                writer.WriteLine("cd " + DestinationRootDirectory);

                foreach (var file in Files)
                {
                    writer.WriteLine("push " + file);    
                }

                writer.WriteLine("quit");
            }
        }
    }
}
