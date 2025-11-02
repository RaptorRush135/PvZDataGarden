namespace PvZDataGarden.Environment;

using MelonLoader.Utils;

using PvZDataGarden.Metadata;

internal static class ModEnvironment
{
    public static string ModDataDirectory { get; }
        = Path.Join(MelonEnvironment.UserDataDirectory, ModInfo.Name);

    public static ModFileInfo GetDataFile(params IEnumerable<string> paths)
    {
        return new(
            Path.Join([ModDataDirectory, .. paths]));
    }
}
