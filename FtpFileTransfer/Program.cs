using System;
using Fclp;

namespace FtpFileTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fclp = new FluentCommandLineBuilder<Arguments>();

            fclp.Setup(arguments => arguments.Files)
                .As('f', "files")
                .WithDescription("The files to be copied from the source to the host")
                .Required();

            fclp.Setup(arguments => arguments.Host)
                .As('h', "host")
                .WithDescription("The Ftp host name")
                .Required();

            fclp.Setup(arguments => arguments.DestinationRootDir)
                .As("dest-root")
                .WithDescription("The root directory on the host.")
                .Required();

            fclp.Setup(arguments => arguments.SourceRootDir)
                .As("src-root")
                .WithDescription("The root directory in the source.")
                .Required();

            fclp.Setup(arguments => arguments.Username)
                .As('u', "username")
                .WithDescription("The username to use to authenticate against the host")
                .Required();

            fclp.Setup(arguments => arguments.Password)
                .As('p', "password")
                .WithDescription("The password to use to authenticate against the hosty")
                .Required();

            fclp.Setup(arguments => arguments.OutputDir)
                .As('o', "output")
                .WithDescription("The directory to output the scripts too")
                .Required();

            var result = fclp.Parse(args);

            if (result.HasErrors == false)
            {
                new FtpFileTransfer().Execute(fclp.Object);
            }
            else
            {
                Console.Write(result.ErrorText);
            }
        }
    }
}
