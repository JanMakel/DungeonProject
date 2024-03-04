using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public Sprite normalSprite; 
    public Sprite pressedSprite; 
    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); 
    }

    public void OnButtonDown()
    {
        if (buttonImage != null && pressedSprite != null)
        {
            
            buttonImage.sprite = pressedSprite;
        }
    }

    public void OnButtonUp()
    {
        if (buttonImage != null && normalSprite != null)
        {
            
            buttonImage.sprite = normalSprite;
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("Dungeon");
    }
}

