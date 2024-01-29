using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int unitLevel;
    public int unitDamage;

    public int unitMaxHp;
    public int unitCurrentHp;

    public int unitDefense;
    public int unitVelocity;
    public int unitDodge;
    public int unitCrit;


    public bool TakeDamage(int damage)
    {

        damage = damage -= unitDefense;
        unitCurrentHp -= damage;

        if(unitCurrentHp <= 0)
        {
            return true;
        }
        else { return false; }

    }
}
