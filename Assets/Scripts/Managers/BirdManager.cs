using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private TextMeshProUGUI birdTimerText;

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
       //TODO: kontroluj cas ak bird away 
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
            PlayerDataManager.Instance.playerData.birdArrivalTime = getBirdArrivalTime();
            UpdateBirdState(BirdState.Out);
        }
    } 

    private DateTimeOffset getBirdArrivalTime(){
        // TODO: prerobit mimo BirdManager cez novu helper class scheduler
        float birdAwayTime = 100f;
        DateTimeOffset birdArrivalTime = DateTimeOffset.Now.AddSeconds(birdAwayTime);
        return birdArrivalTime;
    }
        
    private void makeBirdReady(){
    }

    private void makeBirdOut(){
    }

    private void initBirdState(){
        DateTimeOffset birdArrivalTime = PlayerDataManager.Instance.playerData.birdArrivalTime;
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
