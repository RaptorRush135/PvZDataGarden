namespace PvZDataGarden.Configuration.Synchronization;

using Il2CppReloaded.Services;

public interface IConfigurationSynchronizationDescriptor
{
    string DefinitionTypeName { get; }

    bool HasCollected { get; }

    void Collect(IDataService dataService);

    void Patch(IDataService dataService);
}
