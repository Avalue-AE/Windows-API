using System;
using System.Threading;
using System.Threading.Tasks;

using Avalue;

namespace HWM
{
    class Program
    {
        static bool IsExit = false;

        static void ShowTemperature(string text, float value)
        {
            if (value == -999) return;

            Console.WriteLine($"{$"{text} temp.:",-20}\t{value} °C");
        }

        static void ShowVoltage(string text, float value)
        {
            if (value == -1) return;

            Console.WriteLine($"{$"{text}:",-20}\t{value:f3} V{((text == "VBAT") ? " (Battery voltage is low (≤ 2.5 V). Replacement is recommended.)" : "")}");
        }

        static void ShowFan(string text, int value)
        {
            if (value == -1) return;

            Console.WriteLine($"{$"{text}:",-20}\t{value} RPM");
        }

        static void Main(string[] args)
        {
            if (AvalueAPI.Start())
            {
                if (AvalueAPI.HWM.Init())
                {
                    Task.Factory.StartNew(() =>
                    {
                        while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                        IsExit = true;
                    });

                    while (!IsExit)
                    {
                        Console.Clear();

                        ShowTemperature("CPU", AvalueAPI.HWM.Temperature_CPU());
                        ShowTemperature("CPU PECI", AvalueAPI.HWM.Temperature_CPU_PECI());
                        ShowTemperature("System", AvalueAPI.HWM.Temperature_System());

                        for (int index = 0; index < 5; index++)
                        {
                            ShowVoltage(AvalueAPI.HWM.Voltage_Text(AvalueAPI.HWM.IC.EC, index), AvalueAPI.HWM.Voltage(AvalueAPI.HWM.IC.EC, index));
                        }
                        for (int index = 0; index < 8; index++)
                        {
                            ShowVoltage(AvalueAPI.HWM.Voltage_Text(AvalueAPI.HWM.IC.SIO, index), AvalueAPI.HWM.Voltage(AvalueAPI.HWM.IC.SIO, index));
                        }

                        for (int index = 0; index < 3; index++)
                        {
                            ShowFan(AvalueAPI.HWM.Fan_Text(index), AvalueAPI.HWM.Fan_Speed(index));
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press \"Escape\" to eixt");

                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("HWM Init FAIL");
                }

                AvalueAPI.Stop();
            }
            else
            {
                Console.WriteLine("API Start FAIL");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}