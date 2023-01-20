using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdManager : MonoBehaviour
{
    public BirdState state;

    public static event Action<BirdState> OnBirdStateChanged;
    
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

    public void makeBirdReady() {
        UpdateBirdState(BirdState.Ready);
    }

    public void petBird() {
        // TODO: implement
        print("pet bird");
    }

    public void trainBird() {
        // TODO: implement
        print("train bird");
    }

    private DateTimeOffset getBirdArrivalTime(){
        // TODO: prerobit mimo BirdManager cez novu helper class scheduler
        float birdAwayTime = 20f;
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
}


public enum BirdState {
    Ready,
    Out,
    GotLoot
}
