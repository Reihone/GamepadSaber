using System;
using HarmonyLib;
using IPA;
using UnityEngine;

namespace GamepadSaber
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static readonly string HarmonyId = "com.reihone.gamepadsaber";
        private Harmony _harmony;

        public void Init(IPA.Logging.Logger logger)
        {
            PluginLog.Logger = logger;
            PluginLog.Debug("Init");
        }

        [OnEnable]
        public void OnEnable()
        {
            _harmony = new Harmony(HarmonyId);
            _harmony.PatchAll();
            PluginLog.Debug("Patched all");
            // Input manager start (singleton must be implemented)
            try { InputManager.Instance.Start(); } catch { }
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmony.UnpatchAll(HarmonyId);
            PluginLog.Debug("Unpatched all");
            try { InputManager.Instance.Stop(); } catch { }
        }
    }
}
