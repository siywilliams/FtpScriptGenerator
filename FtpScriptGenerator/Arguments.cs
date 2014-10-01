using System.Collections.Generic;

namespace FtpScriptGenerator
{
    public class Arguments
    {
        public string Host { get; set; }
        public string DestinationRootDir { get; set; }
        public List<string> Files { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SourceRootDir { get; set; }
        public string OutputDir { get; set; }
    }
}
