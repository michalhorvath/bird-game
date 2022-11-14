using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData;

    public static PlayerDataManager Instance;

    void Awake() {
        Instance = this;
        load();
    }

    void Start()
    {
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        print(playerData);
    }

    void OnDestroy(){
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    void Update()
    {
        
    }

    void load(){
        playerData = SaveLoadSystem.loadPlayerData();    
        if (playerData == null){
            playerData = new PlayerData();
        }
    }

    void save(){
        SaveLoadSystem.savePlayerData(playerData);
    }

    void OnBirdStateChanged(BirdState birdState){
        save();
    }
}
