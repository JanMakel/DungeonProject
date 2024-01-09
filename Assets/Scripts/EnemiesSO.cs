using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Character/Enemy")]
public class EnemiesSO : ScriptableObject
{
    public int attack;
    public int defense;
    public int hp;
    public int velocity;
    public int dodge;
    public int critic;
    public Sprite sprite;
}
