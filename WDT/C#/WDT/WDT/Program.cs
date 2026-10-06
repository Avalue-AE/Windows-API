using System;
using System.Threading;

using Avalue;

namespace WDT
{
    class Program
    {
        static void Countdown()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("WDT Start 30 sec");
                Console.WriteLine();
                Console.WriteLine($"WDT Countdown: {AvalueAPI.WDT.Countdown()}s");
                Console.WriteLine();
                Console.WriteLine("Press \"Escape\" to stop");

                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            if (AvalueAPI.Start())
            {
                if (AvalueAPI.WDT.Init())
                {
                    AvalueAPI.WDT.Start(AvalueAPI.WDT.UNIT.SECOND, 30);

                    Thread countdown = new Thread(Countdown);

                    countdown.Start();

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        AvalueAPI.WDT.Stop();

                        countdown.Abort();
                    }
                }
                else
                {
                    Console.WriteLine("WDT Init FAIL");
                }

                AvalueAPI.WDT.Disable();
                AvalueAPI.Stop();
            }
            else
            {
                Console.WriteLine("AvalueAPI Start FAIL");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}