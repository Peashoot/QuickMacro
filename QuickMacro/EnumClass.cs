using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMacro
{
    public class EnumClass
    {
        /// <summary>
        /// 辅助键名称。
        /// Alt, Ctrl, Shift, WindowsKey
        /// </summary>
        [Flags()]
        public enum KeyModifiers { None = 0, Alt = 1, Ctrl = 2, Shift = 4, Win = 8 }

        /// <summary>
        /// 主键名称。
        /// </summary>
        [Flags()]
        public enum KeyMain
        {
            // 摘要:
            //     从键值提取修饰符的位屏蔽。
            Modifiers = -65536,
            //
            // 摘要:
            //     没有按任何键。
            None = 0,
            //
            // 摘要:
            //     鼠标左按钮。
            LButton = 1,
            //
            // 摘要:
            //     鼠标右按钮。
            RButton = 2,
            //
            // 摘要:
            //     Cancel 键。
            Cancel = 3,
            //
            // 摘要:
            //     鼠标中按钮（三个按钮的鼠标）。
            MButton = 4,
            //
            // 摘要:
            //     第一个 X 鼠标按钮（五个按钮的鼠标）。
            XButton1 = 5,
            //
            // 摘要:
            //     第二个 X 鼠标按钮（五个按钮的鼠标）。
            XButton2 = 6,
            //
            // 摘要:
            //     Backspace 键。
            Back = 8,
            //
            // 摘要:
            //     The TAB key.
            Tab = 9,
            //
            // 摘要:
            //     The ESC key.
            Escape = 27,
            //
            // 摘要:
            //     空格键。
            Space = 32,
            //
            // 摘要:
            //     The PAGE UP key.
            PageUp = 33,
            //
            // 摘要:
            //     The PAGE DOWN key.
            PageDown = 34,
            //
            // 摘要:
            //     The END key.
            End = 35,
            //
            // 摘要:
            //     The HOME key.
            Home = 36,
            //
            // 摘要:
            //     向左键。
            Left = 37,
            //
            // 摘要:
            //     向上键。
            Up = 38,
            //
            // 摘要:
            //     向右键。
            Right = 39,
            //
            // 摘要:
            //     向下键。
            Down = 40,
            //
            // 摘要:
            //     Print Screen 键。
            PrintScreen = 44,
            //
            // 摘要:
            //     The INS key.
            Insert = 45,
            //
            // 摘要:
            //     The DEL key.
            Delete = 46,
            //
            // 摘要:
            //     The 0 key.
            D0 = 48,
            //
            // 摘要:
            //     The 1 key.
            D1 = 49,
            //
            // 摘要:
            //     The 2 key.
            D2 = 50,
            //
            // 摘要:
            //     The 3 key.
            D3 = 51,
            //
            // 摘要:
            //     The 4 key.
            D4 = 52,
            //
            // 摘要:
            //     The 5 key.
            D5 = 53,
            //
            // 摘要:
            //     The 6 key.
            D6 = 54,
            //
            // 摘要:
            //     The 7 key.
            D7 = 55,
            //
            // 摘要:
            //     The 8 key.
            D8 = 56,
            //
            // 摘要:
            //     The 9 key.
            D9 = 57,
            //
            // 摘要:
            //     A 键。
            A = 65,
            //
            // 摘要:
            //     B 键。
            B = 66,
            //
            // 摘要:
            //     C 键。
            C = 67,
            //
            // 摘要:
            //     D 键。
            D = 68,
            //
            // 摘要:
            //     E 键。
            E = 69,
            //
            // 摘要:
            //     F 键。
            F = 70,
            //
            // 摘要:
            //     G 键。
            G = 71,
            //
            // 摘要:
            //     H 键。
            H = 72,
            //
            // 摘要:
            //     I 键。
            I = 73,
            //
            // 摘要:
            //     J 键。
            J = 74,
            //
            // 摘要:
            //     K 键。
            K = 75,
            //
            // 摘要:
            //     L 键。
            L = 76,
            //
            // 摘要:
            //     M 键。
            M = 77,
            //
            // 摘要:
            //     N 键。
            N = 78,
            //
            // 摘要:
            //     O 键。
            O = 79,
            //
            // 摘要:
            //     P 键。
            P = 80,
            //
            // 摘要:
            //     Q 键。
            Q = 81,
            //
            // 摘要:
            //     R 键。
            R = 82,
            //
            // 摘要:
            //     S 键。
            S = 83,
            //
            // 摘要:
            //     T 键。
            T = 84,
            //
            // 摘要:
            //     U 键。
            U = 85,
            //
            // 摘要:
            //     V 键。
            V = 86,
            //
            // 摘要:
            //     W 键。
            W = 87,
            //
            // 摘要:
            //     X 键。
            X = 88,
            //
            // 摘要:
            //     Y 键。
            Y = 89,
            //
            // 摘要:
            //     Z 键。
            Z = 90,
            //
            // 摘要:
            //     The 0 key on the numeric keypad.
            NumPad0 = 96,
            //
            // 摘要:
            //     The 1 key on the numeric keypad.
            NumPad1 = 97,
            //
            // 摘要:
            //     数字键盘上的 2 键。
            NumPad2 = 98,
            //
            // 摘要:
            //     数字键盘上的 3 键。
            NumPad3 = 99,
            //
            // 摘要:
            //     数字键盘上的 4 键。
            NumPad4 = 100,
            //
            // 摘要:
            //     数字键盘上的 5 键。
            NumPad5 = 101,
            //
            // 摘要:
            //     数字键盘上的 6 键。
            NumPad6 = 102,
            //
            // 摘要:
            //     数字键盘上的 7 键。
            NumPad7 = 103,
            //
            // 摘要:
            //     The 8 key on the numeric keypad.
            NumPad8 = 104,
            //
            // 摘要:
            //     The 9 key on the numeric keypad.
            NumPad9 = 105,
            //
            // 摘要:
            //     乘号键。
            Multiply = 106,
            //
            // 摘要:
            //     加号键。
            Add = 107,
            //
            // 摘要:
            //     分隔符键。
            Separator = 108,
            //
            // 摘要:
            //     减号键。
            Subtract = 109,
            //
            // 摘要:
            //     句点键。
            Decimal = 110,
            //
            // 摘要:
            //     除号键。
            Divide = 111,
            //
            // 摘要:
            //     The F1 key.
            F1 = 112,
            //
            // 摘要:
            //     The F2 key.
            F2 = 113,
            //
            // 摘要:
            //     The F3 key.
            F3 = 114,
            //
            // 摘要:
            //     The F4 key.
            F4 = 115,
            //
            // 摘要:
            //     The F5 key.
            F5 = 116,
            //
            // 摘要:
            //     The F6 key.
            F6 = 117,
            //
            // 摘要:
            //     The F7 key.
            F7 = 118,
            //
            // 摘要:
            //     The F8 key.
            F8 = 119,
            //
            // 摘要:
            //     The F9 key.
            F9 = 120,
            //
            // 摘要:
            //     The F10 key.
            F10 = 121,
            //
            // 摘要:
            //     The F11 key.
            F11 = 122,
            //
            // 摘要:
            //     The F12 key.
            F12 = 123
        }
    }
}
