#ifdef __cplusplus
#define EXPORT extern "C" __declspec(dllexport)
#else
#define EXPORT __declspec(dllexport)
#endif

#pragma region AvalueAPI
enum class ACCESS
{
	IOPORT, MEMORY
};

enum class RWSIZE
{
	BYTE, WORD, DWORD
};

EXPORT unsigned long AvalueAPI_Version();
EXPORT wchar_t* AvalueAPI_Version_Text();
EXPORT bool AvalueAPI_Start();
EXPORT bool AvalueAPI_Stop();
EXPORT unsigned long AvalueAPI_Read(ACCESS access, RWSIZE size, unsigned long command);
EXPORT bool AvalueAPI_Write(ACCESS access, RWSIZE size, unsigned long command, unsigned long data);
#pragma endregion

#pragma region Info
enum class PWR
{
	NA = -1, AT, ATX
};

struct Disk
{
	wchar_t* Letter;
	int Health;
	int Temperature;
	int PowerCycles;
	int	PowerOnHours;
	int	UnsafeShutdowns;
};

EXPORT wchar_t* DMI_SystemManufacturer();
EXPORT wchar_t* DMI_SystemProduct();
EXPORT wchar_t* DMI_SystemSerialNumber();
EXPORT wchar_t* DMI_SystemSKUNumber();
EXPORT wchar_t* DMI_BaseboardVersion();
EXPORT wchar_t* DMI_BaseboardSerialNumber();
EXPORT wchar_t* Manufacturer();
EXPORT wchar_t* Motherboard();
EXPORT wchar_t* BIOS_Version();
EXPORT wchar_t* EC_Version();
EXPORT wchar_t* CPU_Name();
EXPORT wchar_t* CPU_Identifier();
EXPORT unsigned long CPU_Microcode();
EXPORT bool CPU_Check();
EXPORT PWR PowerMode();
EXPORT wchar_t** Network(int* size);
EXPORT int __stdcall DiskList(Disk*& list);
#pragma endregion

#pragma region Setting
enum class TYPE
{
	NA = -1, RS232, RS422, RS485
};

enum class STATE
{
	NA = -1, DISABLE, ENABLE
};

EXPORT int AMP_Gain_Get();
EXPORT bool AMP_Gain_Set(int value);
EXPORT wchar_t* AMP_Gain_Text(int value);
EXPORT TYPE COM_Type_Get(int number);
EXPORT bool COM_Type_Set(int number, TYPE type);
EXPORT STATE Touch_Get();
EXPORT bool Touch_Set(STATE state);
EXPORT STATE USB_Standby_Power_Get(int number);
EXPORT bool USB_Standby_Power_Set(int number, STATE state);
EXPORT bool BuzzerMute();
EXPORT bool BuzzerBeep(int hz);
EXPORT bool BuzzerBeepTime(int hz, int ms);
#pragma endregion

#pragma region SMBUS
enum class STATUS
{
	NA = -1, READY, HBSY, INTR, DERR, BERR, FAIL, SMSTS, IUS
};

EXPORT bool SMBUS_Init();
EXPORT bool SMBUS_Disable();
EXPORT STATUS SMBUS_Status();
EXPORT bool SMBUS_Read(RWSIZE size, unsigned char addr, unsigned char reg, unsigned long* data);
EXPORT bool SMBUS_Write(RWSIZE size, unsigned char addr, unsigned char reg, unsigned long data);
EXPORT bool SMBUS_I2C_Enable();
EXPORT bool SMBUS_I2C_Disable();
#pragma endregion

#pragma region EC
EXPORT bool EC_Init_Default();
EXPORT bool EC_Init(unsigned short id);
EXPORT bool EC_Disable();
EXPORT unsigned short EC_ID();
EXPORT unsigned char EC_BRAM_Read(unsigned char reg);
EXPORT bool EC_BRAM_Write(unsigned char reg, unsigned char data);
EXPORT unsigned char EC_SRAM_Read(unsigned short addr);
EXPORT bool EC_SRAM_Write(unsigned short addr, unsigned char data);
#pragma endregion

#pragma region SIO
EXPORT bool SIO_Init();
EXPORT bool SIO_Disable();
EXPORT bool SIO_GPIO_Init();
EXPORT unsigned char SIO_GPI_Read();
EXPORT unsigned char SIO_GPO_Read();
EXPORT bool SIO_GPO_Write(unsigned char data);
#pragma endregion

#pragma region DIO
enum class MAPPING
{
	NA = -1, IO2 = 2, IO4 = 4, IO6 = 6, IO8 = 8, IO10 = 10, IO12 = 12, IO14 = 14, IO16 = 16
};

EXPORT bool DIO_Init();
EXPORT bool DIO_Init_Default();
EXPORT bool DIO_Disable();
EXPORT MAPPING DIO_MappingType();
EXPORT unsigned char DIO_Config_Get(int device, int port);
EXPORT bool DIO_Config_Set(int device, int port, unsigned char data);
EXPORT unsigned char DIO_Read(int device, int port);
EXPORT unsigned char DIO_ReadPin(int device, int port, int pin);
EXPORT bool DIO_Write(int device, int port, unsigned char data);
EXPORT bool DIO_WritePin(int device, int port, int pin, unsigned char data);
#pragma endregion

#pragma region WDT
enum class UNIT
{
	SECOND, MINUTE
};

EXPORT bool WDT_Init();
EXPORT bool WDT_Disable();
EXPORT bool WDT_Start(UNIT unit, unsigned short time);
EXPORT bool WDT_Stop();
EXPORT int WDT_Countdown();
#pragma endregion

#pragma region HWM
enum class IC
{
	EC, SIO
};

EXPORT bool HWM_Init();
EXPORT bool HWM_Disable();
EXPORT float HWM_Temperature_CPU();
EXPORT float HWM_Temperature_CPU_PECI();
EXPORT float HWM_Temperature_System();
EXPORT float HWM_Voltage(IC ic, int number);
EXPORT wchar_t* HWM_Voltage_Text(IC ic, int number);
EXPORT int HWM_PWM_Get(int number);
EXPORT bool HWM_PWM_Set(int number, unsigned char value);
EXPORT wchar_t* HWM_PWM_Text(int number);
EXPORT int HWM_Fan_Mode_Get(int number);
EXPORT bool HWM_Fan_Mode_Set(int number, int mode);
EXPORT wchar_t* HWM_Fan_Mode_Text(int number);
EXPORT int HWM_Fan_Speed_Get(int number);
EXPORT int HWM_Fan_PWM_Get(int number);
EXPORT bool HWM_Fan_PWM_Set(int number, unsigned char value);
EXPORT wchar_t* HWM_Fan_Text(int number);
#pragma endregion

#pragma region LCD
enum class SPEC
{
	NA = -1,
	R1024X768_B24_C1, R800X600_B18_C1, R1024X768_B18_C1, R1366X768_B18_C1,
	R1024X600_B18_C1, R1280X800_B18_C1, R1920X1200_B24_C2, R640X480_B18_C1,
	R800X480_B18_C1, R1920X1080_B18_C2, R1280X1024_B24_C2, R1440X900_B18_C2,
	R1600X1200_B24_C2, R1366X768_B24_C1, R1920X1080_B24_C2, R1680X1050_B24_C2
};

enum class CLOCK
{
	NA = -1, F200, F300, F400, F500, F700, F1K, F2K, F3K, F5K, F10K, F20K
};

enum class CTRL
{
	NA = -1, BIOS, BUTTON, VR, OS
};

enum class LIGHT
{
	NA = -1, OFF, ON
};

EXPORT bool LCD_Init();
EXPORT bool LCD_Disable();
EXPORT SPEC LCD_Type();
EXPORT CLOCK LCD_Clock_Get();
EXPORT bool LCD_Clock_Set(CLOCK clock);
EXPORT CTRL LCD_Control_Get();
EXPORT bool LCD_Control_Set(CTRL ctrl);
EXPORT LIGHT LCD_Backlight_Get();
EXPORT bool LCD_Backlight_Set(LIGHT light);
EXPORT int LCD_Brightness_Get();
EXPORT bool LCD_Brightness_Set(unsigned char value);
#pragma endregion