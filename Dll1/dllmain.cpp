// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

extern "C" __declspec(dllexport) int get();
extern "C" __declspec(dllexport) void set(int temp);

#pragma data_seg (".SHAREDMEMORY")
int test = 3;
static int num = 33;
int get()
{
	return num;
}

void set(int temp)
{
	num = temp;
}
#pragma data_seg()
#pragma comment(linker,"/SECTION:.SHAREDMEMORY,RWS")

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}