#pragma once

#include <Windows.h>
#include <vcclr.h>

#define CUSTOM_CLASS_NAME  L"Starts2000.Window"

namespace RegisterFormClass
{
	using namespace System;
	using namespace System::Windows::Forms;
	using namespace System::Runtime::InteropServices;

	private delegate LRESULT WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

	public ref class MyRegisterForm
	{
	public:
		static MyRegisterForm();
		MyRegisterForm();
		MyRegisterForm(String ^caption);
		~MyRegisterForm();
		void Create();
		void Show();
	private:
		String ^_caption;
		HWND _hWnd;
		static GCHandle _windowProcHandle;
		static LRESULT WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
		static void ProcessExit(Object^ sender, EventArgs^ e);
	};
}
