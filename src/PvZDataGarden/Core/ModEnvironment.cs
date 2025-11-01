namespace PvZDataGarden;

using MelonLoader.Utils;

public static class ModEnvironment
{
    public static string ModDirectory { get; }
        = Path.Join(MelonEnvironment.ModsDirectory, ModInfo.Name);

    public static string EnsureFilePath(params IEnumerable<string> paths)
    {
        string path = Path.Join([ModDirectory, .. paths]);

        string? directory = Path.GetDirectoryName(path)
            ?? throw new InvalidOperationException(
                $"Failed to get directory name from path: '{path}'");

        Directory.CreateDirectory(directory);

        return path;
    }
}
