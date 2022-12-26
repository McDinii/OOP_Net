using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class NNDFileManager
    {
        public static void GetAllDirsAndFilesOfDisk(string diskName)
        {
            var allDrives = DriveInfo.GetDrives();
            if (allDrives.Any(drive => drive.Name == diskName))
            {
                var dir = new DirectoryInfo(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12");
                if (dir.GetDirectories("NNDInspect").Length == 0)
                {
                    var subDir = dir.CreateSubdirectory("NNDInspect");
                    var dr = new DirectoryInfo(diskName);
                    using (var file = new StreamWriter(subDir.FullName + @"\" + "NNDDirInfo.txt"))
                    {
                        file.WriteLine("----------Directory----------");
                        foreach (var d in dr.GetDirectories())
                            file.WriteLine($"{d.Name}");
                        file.WriteLine("-------------------------------");

                        file.WriteLine("----------Files----------");
                        foreach (var d in dr.GetFiles())
                            file.WriteLine($"{d.Name}");
                        file.WriteLine("-------------------------");
                    }
                    var dirInfo = new FileInfo(subDir.FullName + @"\" + "NNDDirInfo.txt");
                    dirInfo.CopyTo(subDir.FullName + @"\" + "NNDDirInfoCOPY.txt");
                    dirInfo.Delete();
                }
            }

            NNDLog.WriteToLog("NNDFileManager.GetAllDirsAndFilesOfDisk()", "", diskName);
        }

        public static void GetAllFilesWithExtension(string dirPath, string extension)
        {
            var directory = new DirectoryInfo(dirPath);
            if (directory.Exists)
            {
                var temp = new DirectoryInfo(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12");
                if (temp.GetDirectories("NNDInspect")[0].GetDirectories("NNDFiles").Length == 0)
                {
                    var files = temp.CreateSubdirectory("NNDFiles");

                    foreach (var file in directory.GetFiles($"*{extension}"))
                        file.CopyTo(files.FullName + @"\" + file.Name);

                    files.MoveTo(temp.GetDirectories("NNDInspect")[0].FullName + "\\NNDFiles");
                }
            }

            NNDLog.WriteToLog("NNDFileManager.GetAllFilesWithExtension()", "", dirPath);
        }

        public static void CreateZip(string dir)
        {
            const string zipName = @"D:\ВУЗ\2nd-year\OOP_Net\Laba_12\NNDInspect\NNDFiles.zip";
            if (new DirectoryInfo(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12\NNDInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(dir, zipName);
                var direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                    innerFile.Delete();
                direct.Delete();
                ZipFile.ExtractToDirectory(zipName, dir);
            }

            NNDLog.WriteToLog("NNDFileManager.CreateZip()", "", dir);
        }
    }
}
