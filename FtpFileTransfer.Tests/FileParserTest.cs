using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FtpFileTransfer.Tests
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void ensure_can_be_constructed()
        {
            new FileParser();
        }

        [TestMethod]
        public void ensure_only_filename_returns_filename_ok()
        {
            const string path = "filename.txt";
            var parser = new FileParser();
            var actual = parser.Parse(path);
            
            Assert.AreEqual(path, actual.Filename);
            Assert.IsTrue(string.IsNullOrEmpty(actual.Directory));
        }

        [TestMethod]
        public void ensure_path_is_parsed_into_directory_and_filename_ok()
        {
            const string path = @"c:\directory\subdirectory\filename.txt";
            var parser = new FileParser();
            var actual = parser.Parse(path);

            Assert.AreEqual("filename.txt", actual.Filename);
            Assert.AreEqual(@"c:\directory\subdirectory", actual.Directory);
        }
    }
}
