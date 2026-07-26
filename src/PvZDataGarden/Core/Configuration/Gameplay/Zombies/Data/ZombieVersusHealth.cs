namespace PvZDataGarden.Configuration.Gameplay.Zombies.Data;

using System.Text.Json.Serialization;

using Il2CppReloaded.Gameplay;

using PvZDataGarden.Extensions;

public sealed record ZombieVersusHealth
{
    [JsonIgnore]
    public bool IsEmpty =>
        this.Body.IsNullOrZero() &&
        this.Armor.IsNullOrZero();

    public int? Body { get; set; }

    public int? Armor { get; set; }

    public void Apply(Zombie zombie)
    {
        if (!this.Body.IsNullOrZero())
        {
            zombie.mBodyHealth = this.Body.Value;
        }

        if (this.Armor is not { } armorValue)
        {
            return;
        }

        if (zombie.mHelmHealth > 0)
        {
            zombie.mHelmHealth = armorValue;
        }
        else if (zombie.mShieldHealth > 0)
        {
            zombie.mShieldHealth = armorValue;
        }
    }
}
