#include <windows.h>

//BOOL Shell_NotifyIcon(DWORD dwMessage, PNOTIFYICONDATA lpdata);

//int APIENTRY WinMain(HINSTANCE hInstance,
//                     HINSTANCE hPrevInstance,
//                     LPSTR     lpCmdLine,
//                     int       nCmdShow)
//{
//	MessageBox(NULL, "���������� ���������!","WinAPI App", 0); //���������
//	return 0;
//}

//LRESULT CALLBACK WindowProcedure(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
//{
//	MessageBox(NULL, "���������� ���������!","WinAPI App", 0); //���������
//    static bool bCreated = false;
//    switch (message)
//    {
//        case WM_DESTROY:
//        {
//            if (bCreated)
//            {
//                NOTIFYICONDATA nid;
//                memset(&nid, 0, sizeof(NOTIFYICONDATA));
//                nid.cbSize = sizeof(NOTIFYICONDATA);
//                nid.hWnd = hWnd;
//                nid.uID = 1;
//                Shell_NotifyIcon(NIM_DELETE, &nid);
//            }
//            PostQuitMessage(0);
//        }
//        break;
// 
//        // �������� �� ���� ����� - ��� �������� � ������� ������ � Tray
//        case WM_LBUTTONDOWN:
//        {
//            NOTIFYICONDATA nid;
//            memset(&nid, 0, sizeof(NOTIFYICONDATA));
//            nid.cbSize = sizeof(NOTIFYICONDATA);
//            nid.hWnd = hWnd;
//            nid.uID = 1;
//            nid.uFlags = NIF_ICON | NIF_MESSAGE | NIF_TIP;
//            nid.uCallbackMessage = WM_USER + 200;
//            nid.hIcon = LoadIcon(NULL, IDI_INFORMATION);
//            lstrcpy (nid.szTip, "Test Tip");
//            Shell_NotifyIcon(NIM_ADD, &nid);
//            ShowWindow(hWnd, SW_HIDE);
//            bCreated = true;
//        }
//        break;
// 
//        default:
//            return DefWindowProc (hWnd, message, wParam, lParam);
//    }
//    return 0;
//}

int WINAPI WinMain(HINSTANCE hInst,
                   HINSTANCE hPreviousInst,
                   LPSTR lpCommandLine,
                   int nCommandShow
               )
{
	int result = MessageBox(NULL, "��� �������� WINAPI?!", "������",
							MB_ICONQUESTION | MB_YESNO);
	switch (result)
	{
	case IDYES: MessageBox (NULL, "����������� � ��� �� ����!!!",
						"�����", MB_OK| MB_ICONASTERISK); break;
	case IDNO:  MessageBox (NULL, "����� ����!!!", "�����",
						MB_OK| MB_ICONSTOP); break;
	}
	return NULL;
}
