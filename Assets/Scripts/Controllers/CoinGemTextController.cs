using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinGemTextController : MonoBehaviour
{
    private UIDocument document; 
    private Button homeCoinsButton;
    private Button homeGemsButton;
    private Button currencyCoinsButton;
    private Button currencyGemsButton;

    void Awake(){
        document = GetComponent<UIDocument>();
        homeCoinsButton = document.rootVisualElement.Q<Button>("HomeCoinsButton");
        homeGemsButton = document.rootVisualElement.Q<Button>("HomeGemsButton");
        currencyCoinsButton = document.rootVisualElement.Q<Button>("CurrencyCoinsButton");
        currencyGemsButton = document.rootVisualElement.Q<Button>("CurrencyGemsButton");

        PlayerDataManager.OnPlayerDataChanged += updateText;
    }

    void OnDestroy(){
        PlayerDataManager.OnPlayerDataChanged -= updateText;
    }

    void Start (){
        updateText("");
    }

    private void updateText(string ignore){
        int coins = PlayerDataManager.coins;
        int gems = PlayerDataManager.gems;

        homeCoinsButton.text = "Coins: " + coins;
        homeGemsButton.text = "Gems: " + gems;
        currencyCoinsButton.text = "Coins: " + coins;
        currencyGemsButton.text = "Gems: " + gems;
    }
}
