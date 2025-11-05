namespace PvZDataGarden.Configuration.Gameplay.Plants.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

public sealed record PlantConfiguration : PlantConfigurationData
{
    private static readonly IReadOnlyList<SeedType> EmptyPlantTypes = [
        SeedType.ExplodeONut,
        SeedType.GiantWallnut,
        SeedType.Sprout];

    public override bool IsEmpty => base.IsEmpty || EmptyPlantTypes.Contains(this.Type);

    public SeedType Type { get; set; }

    public static PlantConfiguration FromDefinition(PlantDefinition definition)
    {
        var configuration = new PlantConfiguration()
        {
            Type = definition.SeedType,
            Cost = definition.SeedCost,
            RefreshTime = definition.RefreshTime,
            LaunchRate = definition.LaunchRate == 0 ? null : definition.LaunchRate,
            Versus = PlantVersusConfiguration.Create(
                cost: definition.VersusCost,
                refreshTime: definition.VersusBaseRefreshTime,
                suddenDeathRefreshTime: definition.VersusSuddenDeathRefreshTime),
        };

        ApplyTypeFilter(configuration);

        return configuration;
    }

    public PlantConfigurationData AsData() => this;

    private static void ApplyTypeFilter(PlantConfiguration configuration)
    {
        switch (configuration.Type)
        {
            case SeedType.Imitater:
                configuration.Cost = null;
                break;
        }
    }
}
