using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    private void Awake()
    {
        instance = this;
    }

    public int currentCoins;

    public CoinPickUp coin;

    public void AddCoint(int cointToAdd)
    {
        currentCoins += cointToAdd;
        UiController.instance.UpdateCoins();
    }
    
    public void DropCoin(Vector3 position, int value)
    {
        CoinPickUp newCoin = Instantiate(coin, position + new Vector3(.2f,.1f,0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }

}
