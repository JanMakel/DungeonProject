using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
     public enum InteractableType { Key, Coin, Chest, Door}

    [SerializeField] private InteractableType type;

    public int amount;

    public InteractableType GetType()
    {
        return type;
    }

   
}
