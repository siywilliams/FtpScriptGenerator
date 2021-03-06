﻿using System.Collections.Generic;
using System.IO;

namespace FtpScriptGenerator
{
    public class FtpScript
    {
        public string FilePath { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DestinationRootDirectory { get; set; }
        public IEnumerable<string> Files { get; set; }

        public void Write()
        {
            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("open " + Host);
                writer.WriteLine(Username);

                if (string.IsNullOrEmpty(Password) == false)
                {
                    writer.WriteLine(Password);
                }
                
                writer.WriteLine("cd " + DestinationRootDirectory);

                foreach (var file in Files)
                {
                    writer.WriteLine("put " + file);    
                }

                writer.WriteLine("quit");
            }
        }
    }
}
