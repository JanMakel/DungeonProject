using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static InteractableObject;

public class Chest : MonoBehaviour
{



    [SerializeField]private InteractableType chestContent;
    public int chestAmount;

    /// <summary>
    /// This function checks if you have a key, if not, you can't open the chest, if you have, and press E you can Interact whith the chest and add the amount
    /// and the type of itmes inside it
    /// </summary>
    /// <param name="Collision">Chest</param>
    private void OnTriggerStay2D(Collider2D Collision)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && InventoryManager.Instance.HasItem(InteractableType.Key))
        {
            InventoryManager.Instance.AddItem(chestContent, chestAmount);
            InventoryManager.Instance.RemoveItem(InteractableType.Key, 1);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need a key to open this chest");
        }
    }



    
}
