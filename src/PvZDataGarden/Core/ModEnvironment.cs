namespace PvZDataGarden;

using MelonLoader.Utils;

internal static class ModEnvironment
{
    public static string ModDirectory { get; }
        = Path.Join(MelonEnvironment.ModsDirectory, ModInfo.Name);

    public static ModFileInfo GetFile(params IEnumerable<string> paths)
    {
        return new(
            Path.Join([ModDirectory, .. paths]));
    }
}
