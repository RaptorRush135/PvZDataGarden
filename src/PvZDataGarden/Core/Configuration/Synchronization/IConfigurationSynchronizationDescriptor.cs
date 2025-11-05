namespace PvZDataGarden.Configuration.Synchronization;

using Il2CppReloaded.Services;

public interface IConfigurationSynchronizationDescriptor
{
    bool HasCollected { get; }

    void Collect(IDataService dataService);

    void Patch(IDataService dataService);
}
