using System.IO;

namespace FtpFileTransfer
{
    public class FileParser
    {
        public FtpFile Parse(string path)
        {
            var file = new FileInfo(path);

            var justDirPath = path
                .Replace(file.Name, string.Empty);

            return new FtpFile(justDirPath, file.Name);
        }
    }
}