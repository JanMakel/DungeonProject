using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //Stats of the units used in Battle System 
    public string unitName;

    public int unitLevel;
    public int unitDamage;

    public int unitMaxHp;
    public int unitCurrentHp;

    public int unitDefense;
    public int unitVelocity;
    public int unitDodge;
    public int unitCrit;

    //Each prefab with this script has is unic Sats

    /// <summary>
    /// This Funtion takes damage maked by the unit pertinent and then checks if the unit is dead, all for the battle system check if you winned or lost
    /// </summary>
    /// <param name="damage"> Damage Taken</param>
    /// <returns>Player or enemy dead or not</returns>
    public bool TakeDamage(int damage)
    {

        damage = damage -= unitDefense;
        unitCurrentHp -= damage;

        if(unitCurrentHp <= 0)
        {
            unitCurrentHp = 0;
            return true;
           
        }
        else { return false; }

    }
}
