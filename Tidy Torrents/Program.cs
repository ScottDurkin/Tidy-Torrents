using System;
using System.IO;

namespace Tidy_Torrents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please paste the path to your torrents");
            String RootStr = Console.ReadLine();

            DirectoryInfo d = new DirectoryInfo(@RootStr);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                String FileExtension = f.Name.Substring(f.Name.Length - 4);
                String FileNameWithoutExtension = f.Name.Remove(f.Name.Length - 4);

                String NewFileName = RenameFile(FileNameWithoutExtension);
                NewFileName = String.Format("{0}{1}", NewFileName, FileExtension);

                String FullPathRename = RootStr + @"\";
                FullPathRename = FullPathRename + NewFileName;

                File.Move(f.FullName, FullPathRename);
                Console.WriteLine("Done - " + FullPathRename);
            }
        }


        static String RenameFile(String File)
        {
            File = File.Replace(".", " ");
            File = File.Replace("1080p ", "");
            File = File.Replace("1080p", "");
            File = File.Replace("720p ", "");
            File = File.Replace("720p", "");
            File = File.Replace("BrRip ", "");
            File = File.Replace("BrRip ", "");
            File = File.Replace("BRrip ", "");
            File = File.Replace("BRrip", "");
            File = File.Replace("Brrip ", "");
            File = File.Replace("Brrip", "");
            File = File.Replace("BluRay", "");


            return File;
        }
    }
}
