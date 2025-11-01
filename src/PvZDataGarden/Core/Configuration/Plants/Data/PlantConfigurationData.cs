namespace PvZDataGarden.Configuration.Plants.Data;

using System.Text.Json.Serialization;

public record PlantConfigurationData
{
    public static readonly string DefaultFileName = "plants.json";

    [JsonIgnore]
    public virtual bool IsEmpty =>
        IsNullOrZero(this.Cost) &&
        IsNullOrZero(this.RefreshTime) &&
        IsNullOrZero(this.LaunchRate) &&
        this.Versus is null;

    public int? Cost { get; set; }

    public int? RefreshTime { get; set; }

    public int? LaunchRate { get; set; }

    public PlantVersusConfiguration? Versus { get; set; }

    public PlantConfigurationData AsData() => this;

    private static bool IsNullOrZero(int? value) => value is null or 0;
}
