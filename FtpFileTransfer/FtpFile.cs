namespace FtpFileTransfer
{
    public class FtpFile
    {
        public FtpFile(string directory, string filename)
        {
            Filename = filename;
            Directory = directory;
        }
        public string Filename { get; private set; }
        public string Directory { get; private set; }
    }
}