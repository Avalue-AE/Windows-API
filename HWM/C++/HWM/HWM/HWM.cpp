#include "stdafx.h"
#include <Windows.h> 

#if _WIN64
#include "api\AvalueAPI x64\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x64\\AvalueAPI.lib")
#else
#include "api\AvalueAPI x86\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x86\\AvalueAPI.lib")
#endif

bool Enabled = true;

static void ShowTemperature(char* text, float value)
{
	if (value == -999) return;

	printf("%-10s:\t%.0f C\r\n", text, value);
}

static void ShowVoltage(wchar_t* text, float value)
{
	if (value == -1) return;

	wchar_t warning[128] = L"";

	if (wcscmp(text, L"VBAT") == 0) wcscpy_s(warning, L" (Battery voltage is low (<= 2.5 V). Replacement is recommended.)");

	wprintf(L"%-10ws:\t%.3f V%s\r\n", text, value, warning);
}

static void ShowFan(wchar_t* text, int value)
{
	if (value == -1) return;

	wprintf(L"%-10ws:\t%d RPM\r\n", text, value);
}

DWORD WINAPI HardwareMonitor(void* data)
{
	while (Enabled)
	{
		system("cls");

		ShowTemperature("CPU", HWM_Temperature_CPU());
		ShowTemperature("CPU PECI", HWM_Temperature_CPU_PECI());
		ShowTemperature("System", HWM_Temperature_System());

		for (int index = 0; index < 5; index++)
		{
			ShowVoltage(HWM_Voltage_Text(IC::EC, index), HWM_Voltage(IC::EC, index));
		}
		for (int index = 0; index < 8; index++)
		{
			ShowVoltage(HWM_Voltage_Text(IC::SIO, index), HWM_Voltage(IC::SIO, index));
		}

		for (int index = 0; index < 3; index++)
		{
			ShowFan(HWM_Fan_Text(index), HWM_Fan_Speed_Get(index));
		}

		printf("\r\nPress \"Enter\" to stop");

		Sleep(1000);
	}

	return 0;
}

int main()
{
	if (AvalueAPI_Start())
	{
		if (HWM_Init())
		{
			HANDLE thread = CreateThread(NULL, 0, HardwareMonitor, NULL, 0, NULL);

			if (thread)
			{
				getchar();

				Enabled = false;

				HWM_Disable();
			}
		}
		else
		{
			printf("HWM Init FAIL\r\n");
		}

		AvalueAPI_Stop();
	}
	else
	{
		printf("API Start FAIL\r\n");
	}

	printf("\r\nPress \"Enter\" to exit");

	getchar();

	return 0;
}