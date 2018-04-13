#pragma once
#include "resource.h"
#include <shellapi.h>
#define TRAY_ICONUID 100

extern HINSTANCE hInst;
void TrayDrawIcon(HWND hWnd);
void TrayDeleteIcon(HWND hWnd);
