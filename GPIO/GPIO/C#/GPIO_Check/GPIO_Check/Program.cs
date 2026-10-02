using System;
using System.IO;
using System.Reflection;
using System.Threading;

using Avalue;

namespace GPIO_Check
{
    class Program
    {
        const int DEVICE = 0;
        const int PORT0 = 0;
        const int PORT1 = 1;
        const byte LOW = 0x00;
        const byte HIGH = 0xFF;

        static int Pin;
        static bool Toggle = true;
        static bool Result = true;

        static void Main(string[] args)
        {
            Console.Clear();

            if (AvalueAPI.Start())
            {
                if (AvalueAPI.DIO.Init_Default())
                {
                    bool result = true;

                    Console.WriteLine("Loopback Test");
                    Console.WriteLine();

                    Pin = (int)AvalueAPI.DIO.MappingType();

                    AvalueAPI.DIO.Write(DEVICE, PORT0, LOW);

                    for (int pin = 0; pin < Pin;)
                    {
                        AvalueAPI.DIO.VALUE data_output;
                        AvalueAPI.DIO.VALUE data_input;

                        if (Toggle)
                        {
                            Console.Write($"Test Port 0/1 Pin {pin}: ");
                        }

                        AvalueAPI.DIO.Write(DEVICE, PORT0, pin, Toggle ? AvalueAPI.DIO.VALUE.HI : AvalueAPI.DIO.VALUE.LO);

                        Thread.Sleep(500);

                        data_output = AvalueAPI.DIO.Read(DEVICE, PORT0).Pin[pin];
                        data_input = AvalueAPI.DIO.Read(DEVICE, PORT1).Pin[pin];

                        result &= (data_output == data_input);

                        Toggle = !Toggle;

                        if (Toggle)
                        {
                            Result &= result;

                            Console.WriteLine($"{(result ? "PASS" : "FAIL")}");

                            result = true;

                            pin++;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Result: {(Result ? "PASS" : "FAIL")}");

                    AvalueAPI.DIO.Disable();
                }
                else
                {
                    Result = false;

                    Console.WriteLine("GPIO Init FAIL");
                }

                AvalueAPI.Stop();
            }
            else
            {
                Result = false;

                Console.WriteLine("AvalueAPI Start FAIL");
            }

            File.WriteAllText($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DIO.log", $"[Response]\r\nResult={(Result ? "PASS" : "FAIL")}");

            //Console.WriteLine();
            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey(true);
        }
    }
}