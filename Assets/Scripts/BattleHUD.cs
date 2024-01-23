using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthPoints;


    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl:" + unit.unitLevel;
        healthPoints.text = "HP:" + unit.unitMaxHp;
    }


    public void SetHp(int hp)
    {
        healthPoints.text += hp;
    }
}
