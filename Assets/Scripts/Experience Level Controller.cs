using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int currentExperience;

    public ExpPickUp pickUp;

    public List<int> experienceLevels;
    public int currentLevel = 1;
    public int levelCount = 100;

    public List<Weapon> weaponsToUpgrade; //用于升级时随机选取武器升级
    
    void Start()
    {
        while (experienceLevels.Count < levelCount)
        {   
            experienceLevels.Add(Mathf.CeilToInt(experienceLevels[^1] * 1.2f));
        }
    }

    void Update()
    {
        
    }
    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
        if (currentExperience >= experienceLevels[currentLevel])
        {
            LevelUp();
        }

        UiController.instance.UpdateExperience(currentExperience, experienceLevels[currentLevel], currentLevel);

    }

    public void SpawnExp(Vector3 position, int expToGive)
    {
        Instantiate(pickUp, position, Quaternion.identity).expValue = expToGive;
    }

    void LevelUp()
    {
        Time.timeScale = 0f;
        currentExperience -= experienceLevels[currentLevel];
        currentLevel++;
        if (currentLevel >= experienceLevels.Count)
        {
            currentLevel = levelCount - 1;
        }

        //PlayerController.instance.activeWeapon.LeveUp(); //以切换到Button进行更新
        UiController.instance.levelUpPanel.SetActive(true);

        //UiController.instance.LvUpSelectionButtons[1].updataButtonDisplay(PlayerController.instance.activeWeapon);
        /*UiController.instance.LvUpSelectionButtons[0].updataButtonDisplay(PlayerController.instance.assignedWeapons[0]);
        UiController.instance.LvUpSelectionButtons[1].updataButtonDisplay(PlayerController.instance.unassignedWeapons[0]);
        UiController.instance.LvUpSelectionButtons[2].updataButtonDisplay(PlayerController.instance.unassignedWeapons[0]);*/

        weaponsToUpgrade.Clear();
        
        List<Weapon> availableWeapons = new List<Weapon>();
        availableWeapons.AddRange(PlayerController.instance.assignedWeapons);
        if(availableWeapons.Count > 0)
        {
            int selected = UnityEngine.Random.Range(0, availableWeapons.Count);
            weaponsToUpgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        if(PlayerController.instance.assignedWeapons.Count + PlayerController.instance.fullyLeveledWeapons.Count < PlayerController.instance.maxWeapons)
        {
            availableWeapons.AddRange(PlayerController.instance.unassignedWeapons);
        }

        for (int i = weaponsToUpgrade.Count;  i < 3; i++) //3为升级可以选择的最大数
        {
            if (availableWeapons.Count > 0)
            {
                int selected = UnityEngine.Random.Range(0, availableWeapons.Count);
                weaponsToUpgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
        }

        for (int i = 0; i < weaponsToUpgrade.Count; i++)
        {
            UiController.instance.LvUpSelectionButtons[i].updataButtonDisplay(weaponsToUpgrade[i]);
        }

        for(int i = 0;i < UiController.instance.LvUpSelectionButtons.Length; i++)
        {
            if(i < weaponsToUpgrade.Count)
            {
                UiController.instance.LvUpSelectionButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UiController.instance.LvUpSelectionButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
