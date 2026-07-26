namespace PvZDataGarden.Configuration.Gameplay.SeedPackets.Data;

using System.Text.Json.Serialization;

using Il2CppReloaded.Data;

using PvZDataGarden.Extensions;

public record SeedPacketConfigurationData : IConfigurationData<PlantDefinition>
{
    [JsonIgnore]
    public bool IsEmpty =>
        this.Cost.IsNullOrZero() &&
        this.RefreshTime.IsNullOrZero() &&
        this.LaunchRate.IsNullOrZero() &&
        this.Versus is null;

    public int? Cost { get; set; }

    public int? RefreshTime { get; set; }

    public int? LaunchRate { get; set; }

    public SeedPacketVersusConfiguration? Versus { get; set; }

    public void Patch(PlantDefinition definition)
    {
        definition.m_seedCost = this.Cost ?? definition.m_seedCost;
        definition.m_refreshTime = this.RefreshTime ?? definition.m_refreshTime;
        definition.m_launchRate = this.LaunchRate ?? definition.m_launchRate;
        this.Versus?.Patch(definition);
    }
}
