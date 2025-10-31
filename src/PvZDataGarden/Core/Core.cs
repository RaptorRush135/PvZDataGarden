namespace PvZDataGarden;

using MelonLoader;

public sealed class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        this.LoggerInstance.Msg("Initialized.");
    }
}
