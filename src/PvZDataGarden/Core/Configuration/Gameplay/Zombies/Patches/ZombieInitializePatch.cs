namespace PvZDataGarden.Configuration.Gameplay.Zombies.Patches;

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

using HarmonyLib;

using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Zombies.Data;
using PvZDataGarden.Unity.Extensions;

[HarmonyPatch]
internal static class ZombieInitializePatch
{
    public static IReadOnlyDictionary<ZombieType, ZombieConfigurationData>? Overrides { get; set; }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(Zombie), nameof(Zombie.ZombieInitialize))]
    private static void Postfix(Zombie __instance)
    {
        if (Overrides == null)
        {
            return;
        }

        if (Overrides.TryGetValue(__instance.mZombieType, out var @override))
        {
            bool isVersus = __instance.mApp.Ref()?.IsVersusMode() ?? false;
            @override.Apply(__instance, isVersus);
        }
    }
}
