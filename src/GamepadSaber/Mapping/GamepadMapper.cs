using System;
using UnityEngine;
using GamepadSaber.Input;

namespace GamepadSaber.Mapping
{
    // Простая логика маппинга: кнопки -> удары, стики -> поворот наклона
    public class GamepadMapper
    {
        public static GamepadMapper Instance { get; } = new GamepadMapper();

        private GamepadMapper() { }

        public void Update()
        {
            // читаем состояние первого геймпада
            if (XInputWrapper.GetState(0, out var state))
            {
                // Пример: A (0x1000) -> правый удар, B -> левый (адаптируй под нужные флаги)
                // Тут нужно развернуть биты wButtons по документации XInput
                ushort buttons = state.Gamepad.wButtons;

                bool a = (buttons & 0x1000) != 0; // XINPUT_GAMEPAD_A
                bool b = (buttons & 0x2000) != 0; // XINPUT_GAMEPAD_B

                if (a)
                {
                    // эмулировать правый удар
                    PluginLog.Debug("Button A pressed -> right slash");
                    EmulateSlash(true);
                }
                if (b)
                {
                    PluginLog.Debug("Button B pressed -> left slash");
                    EmulateSlash(false);
                }

                // Стековые оси: преобразуем в углы и применяем к саберам (если реализовано)
                float lx = state.Gamepad.sThumbLX / 32767f;
                float ly = state.Gamepad.sThumbLY / 32767f;
                // TODO: применить к трансформам саберов
            }
        }

        private void EmulateSlash(bool right)
        {
            // Заглушка: отметим в лог. Реальная эмуляция должна триггерить то, что игра ожидает
            PluginLog.Info($"EmulateSlash: {(right ? "Right" : "Left")}");
        }
    }
}
