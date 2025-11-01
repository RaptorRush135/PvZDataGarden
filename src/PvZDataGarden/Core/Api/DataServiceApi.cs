namespace PvZDataGarden.Api;

using HarmonyLib;

using Il2CppReloaded;
using Il2CppReloaded.Services;

using Il2CppTekly.Injectors;

using MelonLoader;

[HarmonyPatch]
public static class DataServiceApi
{
    public static event Action<IDataService>? OnReady;

    [HarmonyPostfix]
    [HarmonyPatch(typeof(AppCore), nameof(AppCore.Provide))]
    private static void AppCore_Provide_Postfix(InjectorContainer container)
    {
        var dataService = container.Get<IDataService>();

        dataService.add_OnReady((Action)(() =>
        {
            Melon<Core>.Logger.Msg("DataService ready!");
            OnReady?.Invoke(dataService);
        }));
    }
}
