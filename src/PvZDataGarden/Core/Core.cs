namespace PvZDataGarden;

using Il2CppReloaded.Services;

using MelonLoader;

using PvZDataGarden.Api;
using PvZDataGarden.Configuration.Plants;
using PvZDataGarden.Extensions;

public sealed class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        DataServiceApi.OnReady += OnDataServiceReady;
    }

    private static void OnDataServiceReady(IDataService dataService)
    {
        var collector = new PlantConfigurationCollector();
        collector.Collect(
            dataService.PlantDefinitions.AsEnumerable());
    }
}
