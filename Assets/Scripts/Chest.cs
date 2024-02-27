using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static InteractableObject;

public class Chest : MonoBehaviour
{



    [SerializeField]private InteractableType chestContent;
    public int chestAmount;


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
