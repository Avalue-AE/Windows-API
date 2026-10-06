#include "stdafx.h"
#include <windows.h>

#if _WIN64
#include "api\AvalueAPI x64\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x64\\AvalueAPI.lib")
#else
#include "api\AvalueAPI x86\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x86\\AvalueAPI.lib")
#endif

const int DEVICE = 0;
const int PORT0 = 0;
const int PORT1 = 1;
const unsigned char LOW = 0x00;

static int Pin;
static bool Toggle = true;
static bool Result = true;

unsigned char Get(unsigned char data, int bit)
{
	return (data >> bit) & 0x01;
}

// true = high, false = low
unsigned char Set(unsigned char data, int bit, bool status)
{
	if (status)
		return data | (1 << bit);
	else
		return data & ~(1 << bit);
}

bool Compare(int bits, unsigned char data1, unsigned char data2)
{
	for (int bit = 0; bit < bits; bit++)
	{
		if (Get(data1, bit) != Get(data2, bit)) return false;
	}

	return true;
}

int main()
{
	FILE* file;

	fopen_s(&file, "GPIO.log", "w");

	if (AvalueAPI_Start())
	{
		if (DIO_Init_Default())
		{
			unsigned char data = LOW;
			bool result = true;

			system("cls");

			printf("Loopback Test\r\n\r\n");

			Pin = (int)DIO_MappingType();

			DIO_Write(DEVICE, PORT0, LOW);

			for (int pin = 0; pin < Pin;)
			{
				unsigned char data_output = LOW;
				unsigned char data_input = LOW;

				if (Toggle)
				{
					printf("Test Port 0/1 Pin %d: ", pin);
				}

				data = Set(data, pin, Toggle);

				DIO_Write(DEVICE, PORT0, data);

				Sleep(500);

				data_output = DIO_Read(DEVICE, PORT0);
				data_input = DIO_Read(DEVICE, PORT1);

				result &= Compare(Pin, data_output, data_input);

				Toggle = !Toggle;

				if (Toggle)
				{
					Result &= result;

					printf("%s\r\n", (result ? "PASS" : "FAIL"));

					result = true;

					pin++;
				}
			}

			printf("\r\nResult: %s\r\n", (Result ? "PASS" : "FAIL"));

			DIO_Disable();
		}
		else
		{
			Result = false;

			printf("GPIO Init FAIL\r\n");
		}

		AvalueAPI_Stop();
	}
	else
	{
		Result = false;

		printf("AvalueAPI Start FAIL\r\n");
	}

	fprintf_s(file, "[Response]\nResult=%s", (Result ? "PASS" : "FAIL"));

	fclose(file);

	/*printf("\r\nPress ""Enter"" to exit");

	getchar();*/

	return 0;
}