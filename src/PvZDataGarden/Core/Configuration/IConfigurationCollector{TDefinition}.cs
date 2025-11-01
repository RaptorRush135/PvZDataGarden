namespace PvZDataGarden.Configuration;

public interface IConfigurationCollector<in TDefinition>
{
    void Collect(IEnumerable<TDefinition> definitions);
}
