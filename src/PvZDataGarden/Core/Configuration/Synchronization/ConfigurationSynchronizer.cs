namespace PvZDataGarden.Configuration.Synchronization;

using MelonLoader;

using PvZDataGarden.Configuration.IO;
using PvZDataGarden.Environment;

using PvZDataGarden.Extensions;

public abstract class ConfigurationSynchronizer<TType, TDefinition, TData>(string fileName)
    : IConfigurationSynchronizer<TType, TDefinition>
    where TType : notnull
    where TData : IConfigurationData<TDefinition>
{
    private readonly ModFileInfo targetFile = ModEnvironment.GetDataFile(fileName);

    public bool HasCollected => this.targetFile.Exists;

    public void Collect(IEnumerable<TDefinition> definitions)
    {
        IReadOnlyDictionary<TType, TData> configurations =
            this.ExtractConfigurations(definitions)
            .ToSorted();

        ConfigurationWriter.Write(
            this.targetFile,
            configurations);
    }

    public void Patch(Func<TType, TDefinition> definitionProvider)
    {
        var configurations = ConfigurationReader.Read<TType, TData>(this.targetFile);
        foreach (var (type, configuration) in configurations)
        {
            TDefinition definition = definitionProvider.Invoke(type);
            configuration.Patch(definition);
        }

        Melon<Core>.Logger.Msg($"Patched {configurations.Count} {typeof(TDefinition).Name}s");
    }

    protected abstract Dictionary<TType, TData> ExtractConfigurations(IEnumerable<TDefinition> definitions);
}
