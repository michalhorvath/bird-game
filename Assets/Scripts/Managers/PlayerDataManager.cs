using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData;

    public static PlayerDataManager Instance;

    private const float AUTOSAVE_INTERVAL = 10f;

    void Awake() {
        Instance = this;
        load();
    }

    void Start()
    {
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        LootManager.OnLootCollected += OnLootCollected;

        StartCoroutine(AutoSaver());
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

    void OnLootCollected(string s){
        save();
    }

    IEnumerator AutoSaver(){
        while(true){
            save();
            yield return new WaitForSecondsRealtime(AUTOSAVE_INTERVAL);
        }
    }
}
