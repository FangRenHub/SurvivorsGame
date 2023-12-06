using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public float timer;

    private bool gameActive;

    void Start()
    {
        gameActive = true;
    }

    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            UiController.instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        gameActive = false;
        StartCoroutine(UiController.instance.EndTimer(timer));
    }
}
