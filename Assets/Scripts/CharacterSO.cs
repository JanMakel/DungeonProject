using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Character/character")]
public class CharacterSO : ScriptableObject
{
    public int attack;
    public int defense;
    public int hp;
    public int velocity;
    public int dodge;
    public int critic;
    public bool enemy;
    public GameObject character;
    public string characterName;

}