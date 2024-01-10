using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleComands : MonoBehaviour
{

    [SerializeField] private Button attackBtn;
    [SerializeField] private Button defenseBtn;
    [SerializeField] private Button objectBtn;


    private void Awake()
    {
        attackBtn.onClick.AddListener(() =>
        {
            Debug.Log("Attack");
        });
        defenseBtn.onClick.AddListener(() =>
        {
            Debug.Log("Defense");
        });
        objectBtn.onClick.AddListener(() =>
        {
            Debug.Log("Object");
        });
    }


}
