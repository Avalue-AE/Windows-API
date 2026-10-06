using System;
using System.Threading;
using System.Threading.Tasks;

using Avalue;

namespace GPIO_Loop
{
    class Program
    {
        static int IO = 0;
        static AvalueAPI.DIO.VALUE[] DO = new AvalueAPI.DIO.VALUE[IO];
        static bool IsExit = false;

        static void Main(string[] args)
        {
            if (AvalueAPI.Start())
            {
                if (AvalueAPI.DIO.Init_Default())
                {
                    IO = (int)AvalueAPI.DIO.MappingType();

                    DO = new AvalueAPI.DIO.VALUE[IO];

                    for (int pin = 0; pin < IO; pin++)
                    {
                        AvalueAPI.DIO.Write(0, 0, pin, AvalueAPI.DIO.VALUE.LO);
                    }

                    Task.Factory.StartNew(() =>
                    {
                        while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

                        IsExit = true;
                    });

                    while (!IsExit)
                    {
                        Console.Clear();

                        for (int pin = 0; pin < IO; pin++)
                        {
                            if (DO[pin] == AvalueAPI.DIO.VALUE.HI)
                                DO[pin] = AvalueAPI.DIO.VALUE.LO;
                            else
                                DO[pin] = AvalueAPI.DIO.VALUE.HI;

                            Console.WriteLine($"Write DO{pin} to {DO[pin]} {(AvalueAPI.DIO.Write(0, 0, pin, DO[pin]) ? "OK" : "FAIL")}");
                        }

                        Thread.Sleep(500);

                        for (int pin = 0; pin < IO; pin++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Read DI{pin}: {AvalueAPI.DIO.Read(0, 1).Pin[pin]}");
                            Console.WriteLine($"Read DO{pin}: {AvalueAPI.DIO.Read(0, 0).Pin[pin]}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press \"Escape\" to eixt");

                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("DIO Init FAIL");
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