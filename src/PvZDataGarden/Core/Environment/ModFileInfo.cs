namespace PvZDataGarden.Environment;

public sealed class ModFileInfo
{
    public ModFileInfo(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        this.Path = path;
        this.Directory = System.IO.Path.GetDirectoryName(path)
            ?? throw new InvalidOperationException(
                $"Failed to get directory name from path: '{path}'.");
    }

    public string Path { get; }

    public string Directory { get; }

    public bool Exists => File.Exists(this.Path);

    public void EnsureDirectoryExists()
    {
        System.IO.Directory.CreateDirectory(this.Directory);
    }

    public Stream Create()
    {
        this.EnsureDirectoryExists();
        return File.Create(this.Path);
    }

    public Stream OpenRead()
    {
        return File.OpenRead(this.Path);
    }
}
