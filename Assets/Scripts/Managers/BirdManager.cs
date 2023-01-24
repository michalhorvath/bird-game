using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdManager : MonoBehaviour
{
    public BirdState state;

    public static event Action<BirdState> OnBirdStateChanged;

    public static event Action<int> OnActiveBirdChanged;
    
    public static BirdManager instance;

    void Awake()
    {
       instance = this; 
    }

    void Start()
    {
        initBirdState();
    }

    void Update()
    {
       DateTimeOffset birdArrivalTime = PlayerDataManager.birdArrivalTime;
       if (state == BirdState.Out && birdArrivalTime < DateTimeOffset.Now){
           UpdateBirdState(BirdState.GotLoot);
       }
    }

    private void UpdateBirdState(BirdState newState){
        state = newState;
        PlayerDataManager.birdState = newState;
        OnBirdStateChanged?.Invoke(newState);
    }

    public void sendBirdOut(){
        if (state == BirdState.Ready){
            PlayerDataManager.birdArrivalTime = getBirdArrivalTime();
            UpdateBirdState(BirdState.Out);
        }
    } 

    public void skipWaiting() {
        if (state == BirdState.Out){
            UpdateBirdState(BirdState.GotLoot);
        }
    }

    public void makeBirdReady() {
        UpdateBirdState(BirdState.Ready);
    }

    public void petBird() {
        // TODO: implement
        print("pet bird");
    }

    private DateTimeOffset getBirdArrivalTime(){
        float birdAwayTime = LootManager.instance.getOutTime();
        DateTimeOffset birdArrivalTime = DateTimeOffset.Now.AddSeconds(birdAwayTime);
        return birdArrivalTime;
    }

    private void initBirdState(){
        BirdState savedState = PlayerDataManager.birdState;
        switch (savedState){
            case BirdState.Ready:
                UpdateBirdState(BirdState.Ready);
                break;
            case BirdState.Out:
                DateTimeOffset birdArrivalTime = PlayerDataManager.birdArrivalTime;
                double seconds = (birdArrivalTime - DateTimeOffset.Now).TotalSeconds;
                if (seconds > 0){
                    UpdateBirdState(BirdState.Out);
                } else {
                    UpdateBirdState(BirdState.GotLoot);
                }
                break;
            case BirdState.GotLoot:
                UpdateBirdState(BirdState.GotLoot);
                break;
        }
    }

    public bool isNewBirdAvailable(){
        return nextBirdAvailable() != -1;
    }

    public int nextBirdAvailable(){
        BirdData[] birdData = PlayerDataManager.getBirdData();
        for(int i = 0; i < birdData.Length; i++){
            if (!birdData[i].isBought){
                return i;
            }
        }
        return -1;
    }

    public void buyNewBird(){
        int nextBird = nextBirdAvailable();
        if (nextBird != -1){
            PlayerDataManager.getBirdData()[nextBird].isBought = true;
            PlayerDataManager.activeBirdID = nextBird;
            PlayerDataManager.gems -= 4;
        }
    }

    public void setActiveBird(int i){
        BirdData[] birdData = PlayerDataManager.getBirdData();
        if (i>=0 && i<=birdData.Length){
            PlayerDataManager.activeBirdID = i;
            OnActiveBirdChanged?.Invoke(i);
        }
    }
}


public enum BirdState {
    Ready,
    Out,
    GotLoot
}
