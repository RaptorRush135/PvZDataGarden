namespace PvZDataGarden.Configuration.Plants.Data;

using Il2CppReloaded.Data;

public sealed record class PlantVersusConfiguration
{
    public int? Cost { get; set; }

    public int? RefreshTime { get; set; }

    public int? SuddenDeathRefreshTime { get; set; }

    public void Patch(PlantDefinition definition)
    {
        definition.m_versusCost = this.Cost
            ?? definition.m_versusCost;
        definition.m_versusBaseRefreshTime = this.RefreshTime
            ?? definition.m_versusBaseRefreshTime;
        definition.m_versusSuddenDeathRefreshTime = this.SuddenDeathRefreshTime
            ?? definition.m_versusSuddenDeathRefreshTime;
    }

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
