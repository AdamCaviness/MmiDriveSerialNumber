using System;
using System.Diagnostics;
using DeviceId.Windows.Mmi.Components;
using DeviceId.Windows.Wmi.Components;

namespace MmiDriveSerialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine($"Getting disk device id...");

            var wmiSw = Stopwatch.StartNew();
			var wmiDiskDeviceId = GetWmiDeviceId();
            Console.WriteLine($"WMI disk device id: {wmiDiskDeviceId}, took {wmiSw.ElapsedMilliseconds}ms.");

			var mmiSw = Stopwatch.StartNew();
            var mmiDiskDeviceId = GetMmiDeviceId();
			Console.WriteLine($"MMI disk device id: {mmiDiskDeviceId}, took {mmiSw.ElapsedMilliseconds}ms.");
        }

		public static string GetMmiDeviceId()
        {
			return new MmiSystemDriveSerialNumberDeviceIdComponent().GetValue();
		}
		public static string GetWmiDeviceId()
		{
			return new WmiSystemDriveSerialNumberDeviceIdComponent().GetValue();
		}
	}
}
