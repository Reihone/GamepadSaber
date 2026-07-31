namespace GamepadSaber.Config
{
    public class ConfigModel
    {
        // Примитивная модель конфига
        public string LeftSlashButton { get; set; } = "B";
        public string RightSlashButton { get; set; } = "A";

        // Дополнительные параметры
        public float StickSensitivity { get; set; } = 1.0f;
        public bool EnablePositionOverride { get; set; } = false;
    }
}
