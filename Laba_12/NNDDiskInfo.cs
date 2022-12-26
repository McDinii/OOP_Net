using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class NNDDiskInfo
    {
        public static void GetFreeDrivesSpace()
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                Console.WriteLine("********************************");
                Console.WriteLine("GetFreeDrivesSpace");
                Console.WriteLine($"Drive Name: {drive.Name}");
                Console.WriteLine($"Drive Type: {drive.DriveType}");
                if (!drive.IsReady) continue;
                Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                Console.WriteLine($"Drive Format: {drive.DriveFormat}");
                Console.WriteLine($"Root Directory: {drive.RootDirectory}");
                Console.WriteLine($"Full Capacity: {drive.TotalSize / Math.Pow(10, 9)} GB");
                Console.WriteLine($"Free Capacity: {drive.TotalFreeSpace / Math.Pow(10, 9)} GB");
                Console.WriteLine($"Available Capacity: {drive.AvailableFreeSpace / Math.Pow(10, 9)} GB");
                Console.WriteLine("********************************\n");
            }

            NNDLog.WriteToLog("NNDDiskInfo.getFreeDrivesSpace()");
        }
    }
}
