using System;
using Avalue;

namespace Info
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{$"DMI System Manufacturer",-30}{AvalueAPI.Info.DMI_SystemManufacturer()}");
            Console.WriteLine($"{$"DMI System Product",-30}{AvalueAPI.Info.DMI_SystemProduct()}");
            Console.WriteLine($"{$"DMI System Serial Number",-30}{AvalueAPI.Info.DMI_SystemSerialNumber()}");
            Console.WriteLine($"{$"DMI System SKU Number",-30}{AvalueAPI.Info.DMI_SystemSKUNumber()}");
            Console.WriteLine($"{$"DMI Baseboard Version",-30}{AvalueAPI.Info.DMI_BaseboardVersion()}");
            Console.WriteLine($"{$"DMI Baseboard Serial Number",-30}{AvalueAPI.Info.DMI_BaseboardSerialNumber()}");
            Console.WriteLine($"{$"Manufacturer",-30}{AvalueAPI.Info.Manufacturer()}");
            Console.WriteLine($"{$"Motherboard",-30}{AvalueAPI.Info.Motherboard()}");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}