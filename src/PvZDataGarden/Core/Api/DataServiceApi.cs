namespace PvZDataGarden.Api;

using HarmonyLib;

using Il2CppReloaded;
using Il2CppReloaded.Services;
using Il2CppReloaded.TreeStateActivities;

using PvZDataGarden.Events;

[HarmonyPatch]
internal static class DataServiceApi
{
    public static readonly OneTimeEvent<IDataService> OnReady = new();

    [HarmonyPostfix]
    [HarmonyPatch(typeof(FrontendActivity), nameof(FrontendActivity.ActiveStarted))]
    private static void ActiveStarted()
    {
        if (!OnReady.Invoked)
        {
            OnReady?.Invoke(AppCore.GetService<IDataService>());
        }
    }
}
