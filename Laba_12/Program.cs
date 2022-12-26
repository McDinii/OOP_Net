namespace Laba_12
{
    public class Program
    {
        public static void Main()
        {
            NNDDiskInfo.GetFreeDrivesSpace();

            NNDFileInfo.GetFileInfo(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12\nndlog.txt");

            NNDDirInfo.GetDirInfo(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12");

            NNDFileManager.GetAllDirsAndFilesOfDisk(@"D:\");

            NNDFileManager.GetAllFilesWithExtension(@"D:\ВУЗ\2nd-year\FoIS", ".txt");

            NNDFileManager.CreateZip(@"D:\ВУЗ\2nd-year\OOP_Net\Laba_12\NNDInspect\NNDFiles");

            NNDLog.SearchByDate(DateTime.Now);
        }
    }
}