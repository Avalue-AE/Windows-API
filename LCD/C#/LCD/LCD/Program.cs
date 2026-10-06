using System;
using Avalue;

namespace LCD
{
    class Program
    {
        static int Brightness = 0;
        static byte[] PWM = { 0x3F, 0x7F, 0xBF, 0xFF };
        static int Index = 0;

        static void Main(string[] args)
        {
            if (AvalueAPI.Start())
            {
                if (AvalueAPI.LCD.Init())
                {
                    AvalueAPI.LCD.Control(AvalueAPI.LCD.CTRL.BIOS);
                    Brightness = AvalueAPI.LCD.Brightness();

                    foreach (var pwm in PWM)
                    {
                        if (Brightness > pwm) Index++;
                    }

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Brightness: {Brightness}");
                        Console.WriteLine();
                        Console.WriteLine("Press \"I\" to increase brightness");
                        Console.WriteLine("Press \"D\" to decrease brightness");
                        Console.WriteLine("Press \"Escape\" to eixt");


                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Escape:
                                AvalueAPI.LCD.Disable();
                                goto EXIT;

                            case ConsoleKey.I:
                                if (Index < 3) Index++;
                                break;

                            case ConsoleKey.D:
                                if (Index > 0) Index--;
                                break;
                        }

                        AvalueAPI.LCD.Brightness(PWM[Index]);
                        Brightness = AvalueAPI.LCD.Brightness();
                    }
                }
                else
                {
                    Console.WriteLine("LCD Init FAIL");
                }

                EXIT:

                AvalueAPI.Stop();
            }
            else
            {
                Console.WriteLine("API Start FAIL");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}