using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesDisplay : MonoBehaviour
{
    [SerializeField] private Text descriptionDisplay;
    [SerializeField] private Image imageDisplay;

    [SerializeField] private string[] descriptions;
    [SerializeField] private Sprite[] images;

    private string textDisplayed;
    private Sprite spriteDisplayed;

    public void DisplayCollectibleInfo(int collectibleID)
    {
        textDisplayed = descriptions[collectibleID];
        spriteDisplayed = images[collectibleID];

        descriptionDisplay.text = textDisplayed;
        imageDisplay.sprite = spriteDisplayed;

        imageDisplay.color = Color.white;
    }
}
