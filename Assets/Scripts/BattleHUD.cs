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

    /// <summary>
    /// This Function sets the HUD for the unit you send it to him, I use this on battle system when I set up de battle
    /// </summary>
    /// <param name="unit">This or the palyer or the enemy</param>
    public void SetHUD(Unit unit)
    {
        
        nameText.text = unit.unitName;
        levelText.text = "Lvl:" + unit.unitLevel;
        healthPoints.text = "HP:" + unit.unitCurrentHp;
    }

    /// <summary>
    /// This function updates the Hp of the unit, I use this when they heal or recieve damage
    /// </summary>
    /// <param name="hp">Amount of hp they have now</param>
    public void SetHp(int hp)
    {
        healthPoints.text = "HP: " + hp.ToString();
    }
    
}
