# GamepadSaber

GamepadSaber — плагин для Beat Saber (PC, non-VR) для управления мечами с помощью Xbox-геймпада.

Цели первой версии:
- Поддержка Xbox-контроллера через XInput
- Базовый маппинг кнопок на удары (левый/правый)
- Основная совместимость с популярными модами: ScoreSaber, Multiplayer, Noodle Extensions, Mapping Extensions, Chroma, Vivfy и др.
- Конфиг через простую модель настроек

Сборка и установка
1. Клонируй репозиторий и открой решение/проект в Visual Studio (Windows).
2. В свойствах проекта установи Target Framework на .NET Framework 4.7.2 (или подходящую для твоей сборки Beat Saber).
3. Добавь ссылки на сборки из папки с Beat Saber (обычно в SteamApps/common/Beat Saber/Beat Saber_Data/Managed):
   - Assembly-CSharp.dll
   - UnityEngine.dll
   - 0Harmony.dll (или добавить через NuGet)
   - IPA/BSIPA — по необходимости
4. Скомпилируй DLL и помести её в папку Plugins игры (Beat Saber/Plugins).

Примечания
- Это каркасный код: для полноценной работы нужны тестирование и правки под конкретную версию Assembly-CSharp.dll (1.48.0).
- BSML/интеграция GUI и продвинутая поддержка кастомных мечей добавятся позже.

Автор: Reihone
Лицензия: MIT
