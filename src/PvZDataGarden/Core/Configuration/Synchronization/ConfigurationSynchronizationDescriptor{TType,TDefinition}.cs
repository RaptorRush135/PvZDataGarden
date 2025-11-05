namespace PvZDataGarden.Configuration.Synchronization;

using Il2CppReloaded.Services;

public sealed class ConfigurationSynchronizationDescriptor<TType, TDefinition>(
    IConfigurationSynchronizer<TType, TDefinition> synchronizer,
    Func<IDataService, IEnumerable<TDefinition>> definitionsGetter,
    Func<IDataService, Func<TType, TDefinition>> definitionProviderGetter)
    : IConfigurationSynchronizationDescriptor
{
    public bool HasCollected => synchronizer.HasCollected;

    public void Collect(IDataService dataService)
    {
        var definitions = definitionsGetter(dataService);
        synchronizer.Collect(definitions);
    }

    public void Patch(IDataService dataService)
    {
        var definitionProvider = definitionProviderGetter(dataService);
        synchronizer.Patch(definitionProvider);
    }
}
