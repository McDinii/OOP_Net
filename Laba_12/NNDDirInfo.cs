using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class NNDDirInfo
    {
        private static DirectoryInfo? GetParentDirs(DirectoryInfo? dirInfo)
        {
            while (true)
            {
                if (dirInfo == null) return dirInfo;

                Console.WriteLine($"{dirInfo.Name}");
                dirInfo = dirInfo.Parent;
            }
        }

        public static void GetDirInfo(string dir)
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetDirInfo");
            var dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                Console.WriteLine("File Wasn't Found");
                return;
            }

            Console.WriteLine($"Count Of Subdirectories: {dirInfo.GetDirectories().Length}");
            Console.WriteLine($"Count Of SubFiles: {dirInfo.GetFiles().Length}");
            Console.WriteLine($"Creation Time: {dirInfo.CreationTime}");
            Console.WriteLine("\nParent Directory:");
            GetParentDirs(dirInfo.Parent);
            Console.WriteLine("********************************\n");

            NNDLog.WriteToLog("NNDDirInfo.GetDirInfo()", "", dir);
        }
    }
}
