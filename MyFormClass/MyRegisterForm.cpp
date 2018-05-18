#include "MyRegisterForm.h"

namespace RegisterFormClass
{
	static MyRegisterForm::MyRegisterForm()
	{
		WNDCLASSEX wc;
		RegisterFormClass::WndProc ^windowProc =
			gcnew RegisterFormClass::WndProc(MyRegisterForm::WndProc);
		_windowProcHandle = GCHandle::Alloc(windowProc);

		ZeroMemory(&wc, sizeof(WNDCLASSEX));
		wc.cbSize = sizeof(WNDCLASSEX);
		wc.style = CS_DBLCLKS;
		wc.lpfnWndProc = reinterpret_cast<WNDPROC>(Marshal::GetFunctionPointerForDelegate(windowProc).ToPointer());
		wc.hInstance = GetModuleHandle(NULL);
		wc.hCursor = LoadCursor(NULL, IDC_ARROW);
		wc.hbrBackground = (HBRUSH)COLOR_WINDOW; //(HBRUSH)GetStockObject(HOLLOW_BRUSH);
		wc.lpszClassName = CUSTOM_CLASS_NAME;

		ATOM classAtom = RegisterClassEx(&wc);
		DWORD lastError = GetLastError();
		if (classAtom == 0 && lastError != ERROR_CLASS_ALREADY_EXISTS)
		{
			throw gcnew ApplicationException("Register window class failed!");
		}

		System::AppDomain::CurrentDomain->ProcessExit += gcnew System::EventHandler(MyRegisterForm::ProcessExit);
	}

	MyRegisterForm::MyRegisterForm() : _caption("Starts2000 Custom ClassName Window")
	{
	}

	MyRegisterForm::MyRegisterForm(String ^caption) : _caption(caption)
	{
	}

	MyRegisterForm::~MyRegisterForm()
	{
		if (_hWnd)
		{
			DestroyWindow(_hWnd);
		}
	}

	void MyRegisterForm::Create()
	{
		DWORD styleEx = 0x00050100;
		DWORD style = 0x17cf0000;

		pin_ptr<const wchar_t> caption = PtrToStringChars(_caption);

		_hWnd = CreateWindowEx(styleEx, CUSTOM_CLASS_NAME, caption, style,
			CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT,
			NULL, NULL, GetModuleHandle(NULL), NULL);
		if (_hWnd == NULL)
		{
			throw gcnew ApplicationException("Create window failed! Error code:" + GetLastError());
		}
	}

	void MyRegisterForm::Show()
	{
		if (_hWnd)
		{
			ShowWindow(_hWnd, SW_NORMAL);
		}
	}

	LRESULT MyRegisterForm::WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
	{
		System::Windows::Forms::Message message = System::Windows::Forms::Message::Create((IntPtr)hWnd,
			(int)msg, (IntPtr)((void*)wParam), (IntPtr)((void*)lParam));
		System::Diagnostics::Debug::WriteLine(message.ToString());

		if (msg == WM_DESTROY)
		{
			PostQuitMessage(0);
			return 0;
		}

		return DefWindowProc(hWnd, msg, wParam, lParam);
	}

	void MyRegisterForm::ProcessExit(Object^ sender, EventArgs^ e)
	{
		UnregisterClass(CUSTOM_CLASS_NAME, GetModuleHandle(NULL));
		if (MyRegisterForm::_windowProcHandle.IsAllocated)
		{
			MyRegisterForm::_windowProcHandle.Free();
		}
	}
}
