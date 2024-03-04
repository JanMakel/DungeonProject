using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //Variable Region
     public enum InteractableType { Key, Coin, Potion}

    [SerializeField] private InteractableType type;

    public int amount;

    public InteractableType Type { get { return type; } }


    

    public int Amount { get { return amount; } }

    

    [SerializeField] private InteractableType chestContent;
    public int chestAmount;

    //Variable Region end

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.CompareTag("Player"))
        {
            // Get the InventoryManager component
            
            if (InventoryManager.Instance != null)
            {
                // Add the item to the inventory
                InventoryManager.Instance.AddItem(type, amount);
                // Destroy the object
                Destroy(gameObject);
            }
        }

        
    }
  

    }
   

