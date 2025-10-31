namespace PvZDataGarden;

using MelonLoader;

public sealed class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Initialized.");
    }
}
