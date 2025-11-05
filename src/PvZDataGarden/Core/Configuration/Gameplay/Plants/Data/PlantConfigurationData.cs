namespace PvZDataGarden.Configuration.Gameplay.Plants.Data;

using System.Text.Json.Serialization;

using Il2CppReloaded.Data;

public record PlantConfigurationData : IConfigurationData<PlantDefinition>
{
    [JsonIgnore]
    public bool IsEmpty =>
        IsNullOrZero(this.Cost) &&
        IsNullOrZero(this.RefreshTime) &&
        IsNullOrZero(this.LaunchRate) &&
        this.Versus is null;

    public int? Cost { get; set; }

    public int? RefreshTime { get; set; }

    public int? LaunchRate { get; set; }

    public PlantVersusConfiguration? Versus { get; set; }

    public void Patch(PlantDefinition definition)
    {
        definition.m_seedCost = this.Cost ?? definition.m_seedCost;
        definition.m_refreshTime = this.RefreshTime ?? definition.m_refreshTime;
        definition.m_launchRate = this.LaunchRate ?? definition.m_launchRate;
        this.Versus?.Patch(definition);
    }

    private static bool IsNullOrZero(int? value) => value is null or 0;
}
