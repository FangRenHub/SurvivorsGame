using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
    public static UiController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider explevelSlider;

    public TMP_Text expLevelText;

    public TMP_Text coinText;

    public LvUpSelectionButton[] LvUpSelectionButtons;

    public GameObject levelUpPanel;

    void Start()
    {
        explevelSlider.value = 0;
    }
    
    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
        explevelSlider.maxValue = levelExp;
        explevelSlider.value = currentExp;
        expLevelText.text = "Level: " + currentLevel;
    }

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateCoins()
    {
        coinText.text = "Coins: " + CoinController.instance.currentCoins;
    }
}
