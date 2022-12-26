using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class NNDFileInfo
    {
        public static void GetFileInfo(string file)
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetFileInfo");
            var fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                System.Console.WriteLine("File Wasn't Found");
                return;
            }

            Console.WriteLine($"Path: {fileInfo.FullName}");
            Console.WriteLine($"Length: {fileInfo.Length} byte");
            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Extension: {fileInfo.Extension}");
            Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
            Console.WriteLine("********************************\n");

            NNDLog.WriteToLog("NNDFileInfo.GetFileInfo()", fileInfo.Name, fileInfo.FullName);

        }

    }
}
