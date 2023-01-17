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
       // checks if it's time for bird to arrive
       DateTimeOffset birdArrivalTime = PlayerDataManager.birdArrivalTime;
       if (state == BirdState.Out && birdArrivalTime < DateTimeOffset.Now){
           UpdateBirdState(BirdState.Ready);
       }
    }

    void OnApplicationFocus(bool hasFocus){
        //TODO: resetuj timer ak treba pripadne sprav loot ready
        if (hasFocus) {
        }
    }

    public void UpdateBirdState(BirdState newState){
        state = newState;

        switch (newState){
            case BirdState.Ready:
                makeBirdReady();
                break;
            case BirdState.Out:
                makeBirdOut();
                break;
            case BirdState.GotLoot:
                break;
        }
        OnBirdStateChanged?.Invoke(newState);
    }

    public void sendBirdOut(){
        if (state == BirdState.Ready){
            PlayerDataManager.birdArrivalTime = getBirdArrivalTime();
            UpdateBirdState(BirdState.Out);
        }
    } 

    private DateTimeOffset getBirdArrivalTime(){
        // TODO: prerobit mimo BirdManager cez novu helper class scheduler
        float birdAwayTime = 20f;
        DateTimeOffset birdArrivalTime = DateTimeOffset.Now.AddSeconds(birdAwayTime);
        return birdArrivalTime;
    }
        
    private void makeBirdReady(){
    }

    private void makeBirdOut(){
    }

    private void initBirdState(){
        DateTimeOffset birdArrivalTime = PlayerDataManager.birdArrivalTime;
        double seconds = (birdArrivalTime - DateTimeOffset.Now).TotalSeconds;
        if (seconds > 0){
            UpdateBirdState(BirdState.Out);
        } else {
            UpdateBirdState(BirdState.Ready);
        }
        // TODO: co ak je loot ready?
    }
}


public enum BirdState {
    Ready,
    Out,
    GotLoot
}
