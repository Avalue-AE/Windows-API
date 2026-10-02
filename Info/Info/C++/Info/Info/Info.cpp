#include "stdafx.h"
#include <Windows.h>

#if _WIN64
#include "api\AvalueAPI x64\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x64\\AvalueAPI.lib")
#else
#include "api\AvalueAPI x86\AvalueAPI.h"
#pragma comment(lib, ".\\api\\AvalueAPI x86\\AvalueAPI.lib")
#endif

#define INFO_STR(name)	printf("%-30s", #name); wprintf(L"%ws\r\n", name());

int main()
{
	system("cls");

	INFO_STR(DMI_SystemManufacturer);
	INFO_STR(DMI_SystemProduct);
	INFO_STR(DMI_SystemSerialNumber);
	INFO_STR(DMI_SystemSKUNumber);
	INFO_STR(DMI_BaseboardVersion);
	INFO_STR(DMI_BaseboardSerialNumber);
	INFO_STR(Manufacturer);
	INFO_STR(Motherboard);

	printf("\r\nPress ""Enter"" to exit");

	getchar();

	return 0;
}