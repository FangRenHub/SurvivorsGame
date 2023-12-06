using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public TMP_Text timeText;

    public LvUpSelectionButton[] LvUpSelectionButtons;

    public GameObject levelUpPanel;

    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;

    public GameObject LevelEndPanel;
    public TMP_Text endTimeText;

    public GameObject pauseScreen;

    void Start()
    {
        explevelSlider.value = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseUnpause();
        }
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

    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        SkipLevelUp();
    }

    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        SkipLevelUp();
    }

    public void PurchasePickupRange()
    {
        PlayerStatController.instance.PurchasePickupRange();
        SkipLevelUp();
    }

    public void PurchaseMaxWeapons()
    {
        PlayerStatController.instance.PurchaseMaxWeapons();
        SkipLevelUp();
    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = "time: " + minutes.ToString() + ":" + seconds.ToString("00");
    }

    public IEnumerator EndTimer(float time)
    {
        yield return new WaitForSeconds(1.5f);
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60);
        endTimeText.text = minutes.ToString() + " mins " + seconds.ToString("00") + " secs";
        LevelEndPanel.SetActive(true);
        levelUpPanel.SetActive(false); 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseUnpause()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            if (levelUpPanel.activeSelf == false)
            {
                Time.timeScale = 1f;
            }
        }
    }
}
