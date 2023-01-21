using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    public static TradeManager instance; 

    void Awake(){
        instance = this;
    }

    private bool hasCoins(int coins){
        return PlayerDataManager.coins >= coins;
    }

    private void spendCoins(int coins){
        PlayerDataManager.coins -= coins;
    }

    private void addCoins(int coins){
        PlayerDataManager.coins += coins;
    }

    private bool hasGems(int gems){
        return PlayerDataManager.gems >= gems;
    }

    private void spendGems(int gems){
        PlayerDataManager.gems -= gems;
    }

    private void addGems(int gems){
        PlayerDataManager.gems += gems;
    }

    public bool skipWaiting(){
        if (hasCoins(100)){
            spendCoins(100);
            BirdManager.instance.skipWaiting();
            return true;
        }
        return false;
    }

    public bool tradeG2C(int gems, int coins){
        if (hasGems(gems)){
            spendGems(gems);
            addCoins(coins);
            return true;
        }
        return false;
    }

    public bool tradeC2G(int coins, int gems){
        if (hasCoins(coins)){
            spendCoins(coins);
            addGems(gems);
            return true;
        }
        return false;
    }
}
