namespace PvZDataGarden.Configuration;

public interface IConfigurationData<in TDefinition>
{
    void Patch(TDefinition definition);
}
