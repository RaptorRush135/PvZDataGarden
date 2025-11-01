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
        var synchronizer = new PlantConfigurationSynchronizer();
        if (!synchronizer.HasCollected)
        {
            synchronizer.Collect(
                dataService.PlantDefinitions.AsEnumerable());

            return;
        }

        synchronizer.Patch(dataService.GetPlantDefinition);
    }
}
