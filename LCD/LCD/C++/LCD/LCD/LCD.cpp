#include "stdafx.h"
#include <conio.h>
#include <Windows.h>

#if _WIN64
#include "api\AvalueAPI x64\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x64\\AvalueAPI.lib")
#else
#include "api\AvalueAPI x86\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x86\\AvalueAPI.lib")
#endif

#define ENUM_STR(name, e_1, e0, e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15)									\
    const char* name##_Strings[] = { #e_1, #e0, #e1, #e2, #e3, #e4, #e5, #e6, #e7, #e8, #e9, #e10, #e11, #e12, #e13, #e14, #e15 };	\
    const char* name##_String(SPEC value) { return name##_Strings[(int)value + 1]; }

ENUM_STR(SPEC, NA,
	R1024X768_B24_C1, R800X600_B18_C1, R1024X768_B18_C1, R1366X768_B18_C1,
	R1024X600_B18_C1, R1280X800_B18_C1, R1920X1200_B24_C2, R640X480_B18_C1,
	R800X480_B18_C1, R1920X1080_B18_C2, R1280X1024_B24_C2, R1440X900_B18_C2,
	R1600X1200_B24_C2, R1366X768_B24_C1, R1920X1080_B24_C2, R1680X1050_B24_C2
)

//ENUM_STR(SPEC, NA,
//	R1024X768B24C1, R800X600B18C1, R1024X768B18C1, R1366X768B18C1, R1024X600B18C1, R1280X800B18C1, R1920X1200B24C2,
//	R1920X1080B18C2, R1280X1024B24C2, R1440X900B18C2, R1600X1200B24C2, R1366X768B24C1, R1920X1080B24C2, CH7513EDP
//)

#define ERROR_VALUE	-1

CTRL Control = CTRL::NA;
CTRL ControlOriginal = CTRL::NA;
int Brightness = ERROR_VALUE;
int BrightnessOriginal = ERROR_VALUE;
int BrightnessMax = 0;
bool Percentage = false;
unsigned char PWMs[] = { 0x3F, 0x7F, 0xBF, 0xFF };
unsigned char Percentages[] = { 25, 50, 75, 100 };

bool CheckPercentage(bool update = false)
{
	if (Percentage)
	{
		if (update) Brightness = Brightness * 100 / 255;

		BrightnessMax = 100;

		return true;
	}
	else
	{
		if (update) Brightness = Brightness * 255 / 100;

		BrightnessMax = 255;

		return false;
	}
}

void GotoPosition(int x, int y)
{
	COORD coord;

	coord.X = x;
	coord.Y = y;

	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void ClearRange(int x1, int y1, int x2, int y2)
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord;

	for (int y = y1; y <= y2; y++)
	{
		coord.X = x1;
		coord.Y = y;

		SetConsoleCursorPosition(handle, coord);

		for (int x = x1; x <= x2; x++) putchar(' ');
	}
}

int main()
{
	if (AvalueAPI_Start())
	{
		if (LCD_Init())
		{
			bool init = true;
			char ch;

			while (true)
			{
				if (init)
				{
					init = false;

					system("cls");

					printf("Type: %s\r\n\r\n", SPEC_String(LCD_Type()));

					if (BrightnessOriginal == ERROR_VALUE)
					{
						BrightnessOriginal = LCD_Brightness_Get();
						Brightness = BrightnessOriginal;
					}
					else Brightness = LCD_Brightness_Get();

					if (ControlOriginal == CTRL::NA)
					{
						ControlOriginal = LCD_Control_Get();
						Control = ControlOriginal;

						Percentage = Control == CTRL::OS;
					}
					else
					{
						CTRL control = Control;

						Control = LCD_Control_Get();

						if (Percentage && (Control == CTRL::BIOS)) CheckPercentage(true);
						else if (Control == CTRL::OS) Percentage = true;
					}

					if (Control == CTRL::BIOS) printf("Test BIOS Control\r\n");
					if (Control == CTRL::OS) printf("Test OS Control\r\n");

					printf("\r\nPress \"+\" to increase,  \"-\" to decrease,");
					printf("\r\n      \"m\" to set mode,  \"u\" to set unit,");
					printf("\r\n      \"s\" to set value, \"a\" to auto test,");
					printf("\r\n      \"q\" to quit.\r\n\r\n");
				}

				GotoPosition(0, 9);

				printf("Current Brightness: %d %s   \r\n\r\n", Brightness, CheckPercentage() ? "%" : "PWM");

				ch = _getch();

				if (ch == '+')
				{
					if (Brightness < BrightnessMax) Brightness++;
					else continue;
				}
				else if (ch == '-')
				{
					if (Brightness > 0) Brightness--;
					else continue;
				}
				else if ((ch == 'm') || (ch == 'M'))
				{
					do
					{
						printf("0: BIOS\r\n");
						printf("3: OS\r\n");
						printf("\r\nSelect Mode: ");

						ch = _getch();

						if ((ch == '0') || (ch == '3')) break;

						GotoPosition(0, 11);
					} while (true);

					CTRL ctrl = (CTRL)(ch - '0');

					if (Control != ctrl)
					{
						LCD_Control_Set(ctrl);

						init = true;
					}

					ClearRange(0, 11, 20, 20);

					continue;
				}
				else if ((ch == 'u') || (ch == 'U'))
				{
					if (Control == CTRL::OS)
					{
						printf("OS control can only use percentage.\r\n");

						Sleep(1000);
					}
					else
					{
						do
						{
							printf("1: PWM\r\n");
							printf("2: Percentage\r\n");
							printf("\r\nSelect Unit: ");

							ch = _getch();

							if ((ch == '1') || (ch == '2')) break;

							GotoPosition(0, 11);
						} while (true);

						bool percentage = ch == '2';

						if (Percentage != percentage)
						{
							Percentage = percentage;

							CheckPercentage(true);
						}
					}

					ClearRange(0, 11, 40, 20);

					continue;
				}
				else if ((ch == 's') || (ch == 'S'))
				{
					char input[BUFSIZ];
					bool valid = true;
					int value;

					printf("Enter Brightness (0 ~ %d): ", BrightnessMax);

					fgets(input, sizeof(input), stdin);

					input[strcspn(input, "\n")] = 0;

					if (strlen(input) == 0) valid = false;

					for (int index = 0; index < strlen(input); index++)
					{
						if (!isdigit(input[index]))
						{
							valid = false;

							break;
						}
					}

					if (valid)
					{
						value = atoi(input);

						if ((value < 0) || (value > BrightnessMax)) valid = false;
					}

					if (valid)
					{
						Brightness = value;

						ClearRange(0, 10, 100, 20);
					}
					else
					{
						printf("\r\nInvalid input.\r\n");

						Sleep(1000);

						ClearRange(0, 10, 100, 20);

						continue;
					}
				}
				else if ((ch == 'a') || (ch == 'A'))
				{
					int brightness;

					printf("Auto Test BIOS Control\r\n");

					LCD_Control_Set(CTRL::BIOS);

					brightness = LCD_Brightness_Get();

					for each (unsigned char pwm in PWMs)
					{
						printf("Set Brightness: %2X\t%s\r\n", pwm, LCD_Brightness_Set(pwm) ? "OK" : "FAIL");

						Sleep(100);

						printf("Get Brightness: %2X\r\n", LCD_Brightness_Get());

						Sleep(1000);
					}

					LCD_Brightness_Set(brightness);

					printf("\r\nAuto Test OS Control\r\n");

					LCD_Control_Set(CTRL::OS);

					brightness = LCD_Brightness_Get();

					for each (unsigned char percentage in Percentages)
					{
						printf("Set Brightness: %3d\t%s\r\n", percentage, LCD_Brightness_Set(percentage) ? "OK" : "FAIL");

						Sleep(100);

						printf("Get Brightness: %3d\r\n", LCD_Brightness_Get());

						Sleep(1000);
					}

					LCD_Brightness_Set(brightness);

					LCD_Control_Set(Control);

					LCD_Brightness_Set(Brightness);

					printf("\r\n");

					system("pause");

					ClearRange(0, 11, 40, 40);

					continue;
				}
				else if ((ch == 'q') || (ch == 'Q')) break;

				LCD_Brightness_Set(((Control == CTRL::BIOS) && Percentage) ? (Brightness * 255 / 100) : Brightness);
			}

			LCD_Brightness_Set(BrightnessOriginal);

			LCD_Control_Set(ControlOriginal);

			LCD_Disable();
		}
		else printf("LCD Init FAIL\r\n");

		AvalueAPI_Stop();
	}
	else printf("API Start FAIL\r\n");

	system("pause");

	return 0;
}