using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempBirdController : MonoBehaviour
{
    public TextMeshProUGUI BirdTimerText;
    public TextMeshProUGUI CoinsText;

    private PlayerData playerData;
    private bool isOut;


    // Start is called before the first frame update
    void Start()
    {
        playerData = SaveLoadSystem.loadPlayerData();
        if (playerData == null) {
            playerData = new PlayerData();
        }
        isOut = false;

        BirdTimerText.text = "";
        CoinsText.text = $"Coins: {playerData.coins}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dispatchBird(){
        if (!isOut) {
            StartCoroutine(DispatchBirdCoroutine(5f + playerData.coins/100f));
        }
    }

    void hideBird(){
        isOut = true;
        transform.position += new Vector3(1000f, 0.0f);
        print("bird dispatched!");
    }

    void showBird(){
        isOut = false;
        transform.position -= new Vector3(1000f, 0.0f);
        print("bird arrived!");
    }

    void getLoot(){
        playerData.coins += 100;
        CoinsText.text = $"Coins: {playerData.coins}";
    }

    IEnumerator DispatchBirdCoroutine(float seconds){
        hideBird();
        while (seconds > 0)
        {
            BirdTimerText.text = $"{seconds / 60:00}:{seconds % 60:00}";
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        BirdTimerText.text="";
        showBird();
        getLoot();
        SaveLoadSystem.savePlayerData(playerData);
        print(DateTimeOffset.Now);
    }
}
