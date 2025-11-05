# 🌱 PvZDataGarden

> Easily tweak plant stats in *Plants vs. Zombies™: Replanted* by editing a simple JSON file.
>
> The mod dumps all plant & projectile definitions (and that includes zombie seed packets) on startup and reloads your edits the next time you launch the game.

## 📦 Download

- [GameBanana](https://gamebanana.com/mods/631190)

## 🧩 Requirements

* 🎮 A copy of **Plants vs. Zombies™: Replanted**
* 🍉 **[MelonLoader](https://github.com/LavaGang/MelonLoader)** - required mod loader

## ✨ Features

* ⬇️ **Automatic Dump** - On the first run, definitions are exported to `.json` files.
* 🛠️ **Editable Stats** - Modify cost, refresh time, launch rate, damage, and more directly in JSON.
* 💾 **Persistent Changes** - The mod reads the files every startup and applies your edits automatically.
* ⚔️ **Versus Mode Support** - Separate configuration for Versus mode.

---

## 🧾 JSON Format

### 🪴 plants.json

```json
{
  "Peashooter": {
    "Cost": 100,
    "RefreshTime": 750,
    "LaunchRate": 150,
    "Versus": {
      "Cost": 100,
      "RefreshTime": 750,
      "SuddenDeathRefreshTime": 250
    }
  },
  "ZombieNormal": {
    "Cost": 50,
    "RefreshTime": 0,
    "Versus": {
      "Cost": 25,
      "RefreshTime": 750,
      "SuddenDeathRefreshTime": 250
    }
  },
  ...
}
```

> [!NOTE]  
> RefreshTime & LaunchRate are in centiseconds.

| Field                           | Description                                         |
| ------------------------------- | --------------------------------------------------- |
| `Cost`                          | Sun cost of the plant seed packet.                  |
| `RefreshTime`                   | Time between plant uses.                            |
| `LaunchRate`                    | Projectile shooting or sun production rate.         |
| `Versus`                        | Overrides used only in Versus mode.                 |

| Versus Field                    | Description                                         |
| ------------------------------- | --------------------------------------------------- |
| `Cost`                          | Sun cost in Versus mode.                            |
| `RefreshTime`                   | Time between plant uses in Versus mode.             |
| `SuddenDeathRefreshTime`        | Refresh time during Sudden Death in Versus mode.    |

### 🟢 projectiles.json

| Field                           | Description                                         |
| ------------------------------- | --------------------------------------------------- |
| `Damage`                        | The amount of damage the projectile deals.          |

```json
{
  "Pea": {
    "Damage": 20
  },
  "Melon": {
    "Damage": 80
  },
  ...
}
```

> [!NOTE]  
> The basic Peashooter uses its own projectile variants:
> - `PeashooterPea`
> - `PeashooterFireball`
>
> All other Peashooter-type plants share the standard projectiles:
> - `Pea`
> - `Fireball`

---

## 🚀 How to Use

1. **Install MelonLoader**

    > [Download here](https://github.com/LavaGang/MelonLoader/releases)

2. **Place the Mod DLL**

    > Copy `PvZDataGarden.dll` file into the game’s `Mods` folder.

3. **Run the game once**

    > The mod creates some `.json` files in `UserData/PvZDataGarden`.

4. **Edit the JSON**

    > Open a `.json` file with a text editor and adjust the values.

5. **Restart the game**

    > Your custom values will now be loaded and applied!

## ⚠️ Notes & Tips

- 🗄️ Backup your original `.json` files to view the original definitions.

- 🧠 Zombie seed packets are also considered “plants.”
This means zombie seed packets appear in the same list and can be tweaked the same way.

- ⚙️ **Optional Properties** - All fields are optional. Any missing ones automatically use their vanilla (default) values.

- ✂️ **Omitting Types** - If you don’t need to modify a specific plant or projectile, simply leave it out of the JSON; it will remain unchanged in-game.

- 🧾 **JSON Extras** - The JSON can contain comments and trailing commas.
