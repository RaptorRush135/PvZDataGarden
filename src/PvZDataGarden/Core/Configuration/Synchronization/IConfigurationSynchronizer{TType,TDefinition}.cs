namespace PvZDataGarden.Configuration.Synchronization;

public interface IConfigurationSynchronizer<TType, TDefinition>
{
    bool HasCollected { get; }

    void Collect(IEnumerable<TDefinition> definitions);

    void Patch(Func<TType, TDefinition> definitionProvider);
}
