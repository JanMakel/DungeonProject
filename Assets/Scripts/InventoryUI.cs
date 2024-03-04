using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI[] itemTexts; // Array of Text elements to display item counts
    public GameObject[] itemImages; // Array of Image elements to display item icons
    public InteractableObject.InteractableType[] itemTypes; // Array of InteractableTypes corresponding to items
    
    public static InventoryUI instance;

    /// <summary>
    /// This function Makes posible the inventory UI appear when you have at least one of the type item collected
    /// and just set active the sprite with the animation in the pertienet loaction
    /// </summary>
    public void InventoryAdding()
    {
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Key))
        {
            itemImages[0].gameObject.SetActive(true);
            itemTexts[0].gameObject.SetActive(true);
        }
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Coin))
        {
            itemImages[1].gameObject.SetActive(true);
            itemTexts[1].gameObject.SetActive(true);
        }
        if (InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Potion))
        {
            itemImages[2].gameObject.SetActive(true);
            itemTexts[2].gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// This function updates the inventory when you collect itmes, just reflexes the amount of the itmes you have
    /// </summary>
    public void SetInventoryNums()
    {
        itemTexts[0].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Key).ToString();
        itemTexts[1].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Coin).ToString();
        itemTexts[2].text = InventoryManager.Instance.GetItemCount(InteractableObject.InteractableType.Potion).ToString();
    }


    /// <summary>
    /// This function makes disapear the pertinent sprite when you don't have at least 1 item of the pertinent item, chekced in the Inventory Manager
    /// </summary>
    public void RemoveInventory()
    {
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Key))
        {
            itemImages[0].gameObject.SetActive(false);
            itemTexts[0].gameObject.SetActive(false);
        }
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Coin))
        {
            itemImages[1].gameObject.SetActive(false);
            itemTexts[1].gameObject.SetActive(false);
        }
        if (!InventoryManager.Instance.HasItem(InteractableObject.InteractableType.Potion))
        {
            itemImages[2].gameObject.SetActive(false);
            itemTexts[2].gameObject.SetActive(false);
        }
    }



    private void Awake()
    {
        // Singleton
        if (instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        instance = this;
    }
}

