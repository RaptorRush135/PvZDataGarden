namespace PvZDataGarden.Configuration;

public interface IConfigurationSynchronizer<TKey, in TDefinition>
{
    bool HasCollected { get; }

    void Collect(IEnumerable<TDefinition> definitions);

    void Patch(Func<TKey, TDefinition> definitionProvider);
}
