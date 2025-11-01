namespace PvZDataGarden.Configuration.Plants;

using Il2CppReloaded.Data;
using Il2CppReloaded.Gameplay;

using PvZDataGarden.Configuration;
using PvZDataGarden.Configuration.IO;
using PvZDataGarden.Configuration.Plants.Data;
using PvZDataGarden.Extensions;

public sealed class PlantConfigurationCollector : IConfigurationCollector<PlantDefinition>
{
    public void Collect(IEnumerable<PlantDefinition> definitions)
    {
        IReadOnlyDictionary<SeedType, PlantConfigurationData> configurations = definitions
            .Select(PlantConfiguration.FromDefinition)
            .Where(p => !p.IsEmpty)
            .ToDictionary(p => p.Type, p => p.AsData())
            .ToSorted();

        ConfigurationWriter.Write(
            ModEnvironment.EnsureFilePath(PlantConfigurationData.DefaultFileName),
            configurations);
    }
}
