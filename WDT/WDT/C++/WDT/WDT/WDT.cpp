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

DWORD WINAPI Countdown(void* data)
{
	while (Enabled)
	{
		system("cls");

		printf("WDT Start 30s\r\n\r\n");
		printf("WDT Countdown: %ds\r\n\r\n", WDT_Countdown());
		printf("Press \"Enter\" to stop");

		Sleep(1000);
	}

	return 0;
}

int main()
{
	if (AvalueAPI_Start())
	{
		if (WDT_Init())
		{
			WDT_Start(UNIT::SECOND, 30);

			HANDLE thread = CreateThread(NULL, 0, Countdown, NULL, 0, NULL);

			if (thread)
			{
				getchar();

				Enabled = false;

				WDT_Stop();
			}
		}
		else
		{
			printf("WDT Init FAIL\r\n");
		}

		WDT_Disable();

		AvalueAPI_Stop();
	}
	else
	{
		printf("AvalueAPI Start FAIL\r\n");
	}

	printf("\r\nPress \"Enter\" to exit");

	getchar();

	return 0;
}