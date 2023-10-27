using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUpable
{
    public WeaponItemsSO Weapon();
    public void ChangeCurrentWeapon(GameObject weaponNew);
}
