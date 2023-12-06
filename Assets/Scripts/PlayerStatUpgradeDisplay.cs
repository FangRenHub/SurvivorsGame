using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUpgradeDisplay : MonoBehaviour
{

    public TMP_Text valueText, costText;

    public Button upgradeButton;
    public TMP_Text buttonText;
    
    
    public void UpdateDisplay(int cost, float oldValue, float newValue)
    {
        valueText.text = "Value : " + oldValue.ToString("F1") + " -> " + newValue.ToString("F1");
        costText.text = "Cost: " + cost;

        if (cost <= CoinController.instance.currentCoins)
        {
            buttonText.color = new Color(1, 1, 1);
            upgradeButton.enabled = true;
           // upgradeButton.SetActive(true);
        }
        else
        {
            upgradeButton.enabled = false;
            buttonText.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
            //upgradeButton.SetActive(false);
        }
    }

    public void ShowMaxLevel()  
    {
        valueText.text = "Max Level";
        costText.text = "Max Level";
        upgradeButton.enabled = false;
        buttonText.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
    }
}
