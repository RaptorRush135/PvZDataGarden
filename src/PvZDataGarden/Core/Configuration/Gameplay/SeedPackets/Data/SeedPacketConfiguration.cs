namespace PvZDataGarden.Configuration.Gameplay.SeedPackets.Data;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Extensions;

public sealed record SeedPacketConfiguration : SeedPacketConfigurationData
{
    public SeedType Type { get; set; }

    public static SeedPacketConfiguration FromDefinition(PlantDefinition definition)
    {
        var configuration = new SeedPacketConfiguration()
        {
            Type = definition.SeedType,
            Cost = definition.SeedCost,
            RefreshTime = definition.RefreshTime,
            LaunchRate = definition.LaunchRate.NullIfDefault(),
            Versus = SeedPacketVersusConfiguration.Create(
                cost: definition.VersusCost,
                refreshTime: definition.VersusBaseRefreshTime,
                suddenDeathRefreshTime: definition.VersusSuddenDeathRefreshTime),
        };

        ApplyTypeFilter(configuration);

        return configuration;
    }

    public SeedPacketConfigurationData AsData() => this;

    private static void ApplyTypeFilter(SeedPacketConfiguration configuration)
    {
        switch (configuration.Type)
        {
            case SeedType.Imitater:
                configuration.Cost = null;
                break;
        }
    }
}
