namespace PvZDataGarden.Configuration.Gameplay.Zombies.Data;

using Il2CppReloaded.Gameplay;

public sealed record ZombieHealth
{
    public int? Body { get; set; }

    public int? Helmet { get; set; }

    public int? Shield { get; set; }

    public int? Flying { get; set; }

    public void Apply(Zombie zombie)
    {
        if (this.Body is { } bodyValue)
        {
            zombie.mBodyHealth = zombie.mBodyMaxHealth = bodyValue;
        }

        if (this.Helmet is { } helmetValue)
        {
            zombie.mHelmHealth = zombie.mHelmMaxHealth = helmetValue;
        }

        if (this.Shield is { } shieldValue)
        {
            zombie.mShieldHealth = zombie.mShieldMaxHealth = shieldValue;
        }

        if (this.Flying is { } flyingValue)
        {
            zombie.mFlyingHealth = zombie.mFlyingMaxHealth = flyingValue;
        }
    }
}
