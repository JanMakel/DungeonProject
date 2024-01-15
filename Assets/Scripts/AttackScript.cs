using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    private HeroesSO heroSO;
    private EnemiesSO enemiesSO;

    private int damage;

    private int hpLeft;


    private void Start()
    {
        enemiesSO.hp = hpLeft;
    }
    public void Attack(GameObject victim)
    {
        damage = heroSO.attack - enemiesSO.defense;
        hpLeft = damage -= hpLeft;
       
    }
}
