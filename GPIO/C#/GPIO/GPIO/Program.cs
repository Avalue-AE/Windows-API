using System;

using Avalue;

namespace GPIO
{
    class Program
    {
        static int IO = 0;
        static AvalueAPI.DIO.VALUE[] DO = new AvalueAPI.DIO.VALUE[IO];
        static bool IsInit = false;

        static void Main(string[] args)
        {
            if (AvalueAPI.Start())
            {
                // Device 0: GPIO pins < 16 pins
                // Port 0 (GP1x) Default Output
                // Port 1 (GP2x) Default Input
                if (AvalueAPI.DIO.Init_Default())
                {
                    IO = (int)AvalueAPI.DIO.MappingType();

                    DO = new AvalueAPI.DIO.VALUE[IO];

                    for (int pin = 0; pin < IO; pin++)
                    {
                        AvalueAPI.DIO.Write(0, 0, pin, AvalueAPI.DIO.VALUE.LO);
                    }

                    while (true)
                    {
                        ConsoleKey key = IsInit ? Console.ReadKey(true).Key : ConsoleKey.R;

                        Console.Clear();

                        switch (key)
                        {
                            case ConsoleKey.Escape:
                                AvalueAPI.DIO.Disable();
                                goto EXIT;

                            case ConsoleKey.R:
                                {
                                    IsInit = true;

                                    AvalueAPI.DIO.DATA data = AvalueAPI.DIO.Read(0, 1);

                                    for (int pin = 0; pin < IO; pin++)
                                    {
                                        Console.WriteLine($"Read DI{pin}: {data.Pin[pin]}");
                                    }

                                    Console.WriteLine();

                                    data = AvalueAPI.DIO.Read(0, 0);

                                    for (int pin = 0; pin < IO; pin++)
                                    {
                                        Console.WriteLine($"Read DO{pin}: {data.Pin[pin]}");
                                    }
                                }
                                break;

                            case ConsoleKey.W:
                                {
                                    for (int pin = 0; pin < IO; pin++)
                                    {
                                        if (DO[pin] == AvalueAPI.DIO.VALUE.HI)
                                        {
                                            DO[pin] = AvalueAPI.DIO.VALUE.LO;
                                        }
                                        else
                                        {
                                            DO[pin] = AvalueAPI.DIO.VALUE.HI;
                                        }

                                        Console.WriteLine($"Write DO{pin} to {DO[pin]} {(AvalueAPI.DIO.Write(0, 0, pin, DO[pin]) ? "OK" : "FAIL")}");
                                    }
                                }
                                break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press \"R\" to read DI & DO status");
                        Console.WriteLine("Press \"W\" to write DO status");
                        Console.WriteLine();
                        Console.WriteLine("Press \"Escape\" to eixt");
                    }
                }
                else
                {
                    Console.WriteLine("DIO Init FAIL");
                }

                EXIT:

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