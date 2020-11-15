using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public int grenades;
    public int bullets;

    public PlayerData(PlayerSystem player, Weapon weapon)
    {
        level = player.level;
        health = player.health;
        grenades = weapon.grenages;
        bullets = weapon.bullets;
    }
}
