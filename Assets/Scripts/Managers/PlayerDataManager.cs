using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData playerData;

    public static PlayerDataManager Instance;

    public static event Action<string> OnPlayerDataChanged;

    public static int coins {
        get {
            return Instance.playerData.coins;
        }
        set {
            Instance.playerData.coins = value;
            Instance.playerDataChanged();
        }
    }

    public static int gems {
        get {
            return Instance.playerData.gems;
        }
        set {
            Instance.playerData.gems = value;
            Instance.playerDataChanged();
        }
    }

    public static int activeBirdID {
        get {
            return Instance.playerData.activeBirdID;
        }
        set {
            Instance.playerData.activeBirdID = value;
            Instance.playerDataChanged();
        }
    }

    public static DateTimeOffset birdArrivalTime {
        get {
            return Instance.playerData.birdArrivalTime;
        }
        set {
            Instance.playerData.birdArrivalTime = value;
            Instance.playerDataChanged();
        }
    }

    public static BirdState birdState {
        get {
            return Instance.playerData.birdState;
        }
        set {
            Instance.playerData.birdState = value;
            Instance.playerDataChanged();
        }
    }

    void Awake() {
        Instance = this;
        load();
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

    public void playerDataChanged(){
        OnPlayerDataChanged?.Invoke("ignore");
        save();
    }

    public static BirdData getActiveBird(){
        return Instance.playerData.birdData[Instance.playerData.activeBirdID];
    }

    public static BirdData[] getBirdData(){
        return Instance.playerData.birdData;
    }

    public static ItemData[] getItemData(){
        return Instance.playerData.itemData;
    }
}
