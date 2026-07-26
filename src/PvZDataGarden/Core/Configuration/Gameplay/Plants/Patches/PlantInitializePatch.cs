namespace PvZDataGarden.Configuration.Gameplay.Plants.Patches;

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

using HarmonyLib;

using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration.Gameplay.Plants.Data;
using PvZDataGarden.Unity.Extensions;

[HarmonyPatch]
internal static class PlantInitializePatch
{
    public static IReadOnlyDictionary<SeedType, PlantConfigurationData>? Overrides { get; set; }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(Plant), nameof(Plant.PlantInitialize))]
    private static void Postfix(Plant __instance)
    {
        if (Overrides == null)
        {
            return;
        }

        if (Overrides.TryGetValue(__instance.mSeedType, out var @override))
        {
            bool isVersus = __instance.mApp.Ref()?.IsVersusMode() ?? false;
            @override.Apply(__instance, isVersus);
        }
    }
}
