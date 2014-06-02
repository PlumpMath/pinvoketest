// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"

BOOL APIENTRY DllMain( HMODULE hModule,
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

// This is an example of an exported variable
extern "C" __declspec(dllexport) bool __stdcall TestFunc() {
	char* arg = "\"c:\\program files (x86)\\microsoft lifecam\\lifeexp.exe\"";
	printf("calling with:\r\n%s\r\n",arg);
	try{
		PathGetArgs(arg);
	}
	catch(...) {
		return false;
	}
	return true;
}

