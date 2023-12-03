using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText, nameLevelText;
    public Image weaponIcon;

    private Weapon theWeapon;

    public void updataButtonDisplay(Weapon theWeapon)
    {
        if (theWeapon.gameObject.activeSelf)
        {
            upgradeDescText.text = theWeapon.weaponStats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;
            nameLevelText.text = theWeapon.name + " - Lv " + theWeapon.weaponLevel;
        }
        else
        {
            upgradeDescText.text = "Unlock\n" + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;
            nameLevelText.text = theWeapon.name;
        }
        this.theWeapon = theWeapon;
    }
    
    public void SelectUpgrade()
    {
        if (this.theWeapon != null)
        {
            if (theWeapon.gameObject.activeSelf)
            {
                this.theWeapon.LeveUp();
            }
            else
            {
                PlayerController.instance.AddWeapon(this.theWeapon);
            }
            UiController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    
}
