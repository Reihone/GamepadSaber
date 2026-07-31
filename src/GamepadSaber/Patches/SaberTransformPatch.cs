using System;
using System.Reflection;
using HarmonyLib;

namespace GamepadSaber.Patches
{
    [HarmonyPatch]
    internal static class SaberTransformPatch
    {
        // Здесь мы намеренно не указываем целевой метод — нужно выяснить конкретный тип/метод в Assembly-CSharp.dll
        static MethodBase TargetMethod()
        {
            // Пример поиска по имени типа в рантайме
            var asm = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in asm)
            {
                if (a.GetName().Name == "Assembly-CSharp")
                {
                    var t = a.GetType("Saber");
                    if (t != null)
                    {
                        var m = t.GetMethod("Update", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        if (m != null) return m;
                    }
                }
            }
            return null;
        }

        static void Postfix(object __instance)
        {
            try
            {
                // Здесь можно получить Transform поля сабера и модифицировать позицию/ротацию
                // var transform = __instance.GetType().GetProperty("transform").GetValue(__instance) as UnityEngine.Transform;
                // Пример: вращение по input. Оставляем заглушку.
                // GamepadMapper.Instance.ApplyToTransform(transform);
            }
            catch (Exception ex)
            {
                PluginLog.Error("SaberTransformPatch Postfix error: " + ex.Message);
            }
        }
    }
}
