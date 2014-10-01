using System.Collections;
using System.Collections.Generic;

namespace FtpScriptGenerator
{
    public class FtpDirectory : IEnumerable<FtpFile>
    {
        public FtpDirectory(string path)
        {
            Path = path;
        }

        private readonly List<FtpFile> _files = new List<FtpFile>();
        public string Path { get; private set; }

        public string Name { get { return System.IO.Path.GetDirectoryName(Path); } }

        public void AddFile(FtpFile file)
        {
            _files.Add(file);
        }

        public IEnumerator<FtpFile> GetEnumerator()
        {
            return _files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _files.GetEnumerator();
        }  
    }
}