namespace PvZDataGarden.Configuration.Plants.Data;

public sealed record class PlantVersusConfiguration
{
    public int? Cost { get; set; }

    public int? RefreshTime { get; set; }

    public int? SuddenDeathRefreshTime { get; set; }

    public static PlantVersusConfiguration? Create(
        int cost,
        int refreshTime,
        int suddenDeathRefreshTime)
    {
        return cost == 0 && refreshTime == 0 && suddenDeathRefreshTime == 0
            ? null
            : new()
            {
                Cost = cost,
                RefreshTime = refreshTime,
                SuddenDeathRefreshTime = suddenDeathRefreshTime,
            };
    }
}
