using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> weaponStats;
    public int weaponLevel;

    [HideInInspector]
    public bool statsUpated;

    public Sprite icon;

    public void LeveUp()
    {
        if(weaponLevel < weaponStats.Count - 1)
        {
            weaponLevel++;
            statsUpated = true;
            
            if(weaponLevel >= weaponStats.Count - 1 )
            {
                PlayerController.instance.fullyLeveledWeapons.Add(this);
                PlayerController.instance.assignedWeapons.Remove(this);
            }
        }
    }
}

[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, timeBetweenAAtacks, amount, duration, strength;
    public string upgradeText;
}