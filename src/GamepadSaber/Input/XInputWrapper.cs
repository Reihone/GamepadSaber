using System;
using System.Runtime.InteropServices;

namespace GamepadSaber.Input
{
    // Упрощённый XInput wrapper (только чтение состояния).
    public static class XInputWrapper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct XINPUT_GAMEPAD
        {
            public ushort wButtons;
            public byte bLeftTrigger;
            public byte bRightTrigger;
            public short sThumbLX;
            public short sThumbLY;
            public short sThumbRX;
            public short sThumbRY;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct XINPUT_STATE
        {
            public uint dwPacketNumber;
            public XINPUT_GAMEPAD Gamepad;
        }

        [DllImport("xinput1_4.dll", EntryPoint = "XInputGetState")]
        private static extern int XInputGetState_1_4(int dwUserIndex, out XINPUT_STATE pState);
        [DllImport("xinput1_3.dll", EntryPoint = "XInputGetState")]
        private static extern int XInputGetState_1_3(int dwUserIndex, out XINPUT_STATE pState);

        public static bool GetState(int userIndex, out XINPUT_STATE state)
        {
            state = new XINPUT_STATE();
            try
            {
                int r = XInputGetState_1_4(userIndex, out state);
                return r == 0;
            }
            catch
            {
                try
                {
                    int r = XInputGetState_1_3(userIndex, out state);
                    return r == 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
