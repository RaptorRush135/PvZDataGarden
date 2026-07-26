namespace PvZDataGarden.Configuration.Gameplay.Zombies.Data;

using Il2CppReloaded.Gameplay;

using PvZDataGarden.Extensions;

public sealed record ZombieVersusConfiguration
{
    public ZombieVersusHealth? Health { get; set; }

    public static ZombieVersusConfiguration? Create(int body, int armor)
    {
        var health = new ZombieVersusHealth
        {
            Body = body.NullIfDefault(),
            Armor = armor.NullIfDefault(),
        };

        return health.IsEmpty
            ? null
            : new()
            {
                Health = health,
            };
    }

    public void Apply(Zombie zombie)
    {
        this.Health?.Apply(zombie);
    }
}
