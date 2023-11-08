using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    // Player heath
    public float health = 20;
    // player speed
    public float speed = 5;
    // player ammo
    public AmmoInformation shotgunAmmo = new AmmoInformation("shotgunAmmo",10);
    public AmmoInformation plasmaAmmo = new AmmoInformation("plasmaAmmo", 20);
    public AmmoInformation rocketAmmo = new AmmoInformation("rocketAmmo", 30);
    public AmmoInformation pistolAmmo = new AmmoInformation("pistolAmmo", 4);
    // player currency
    public int gold = 0;
    public int gem = 0;
}

public class AmmoInformation {

    public string name;
    public int quatity;
    public AmmoInformation(string name, int quatity)
    {
        this.name = name;
        this.quatity = quatity;
    }
}

