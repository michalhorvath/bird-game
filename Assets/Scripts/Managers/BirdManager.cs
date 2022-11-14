using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private TextMeshProUGUI birdTimerText;

    public BirdState State;

    public static event Action<BirdState> OnBirdStateChanged;

    void Awake()
    {
        
    }

    void Start()
    {
       OnBirdStateChanged(BirdState.Ready); 
    }

    void Update()
    {
        
    }

    public void UpdateBirdState(BirdState newState){
        State = newState;

        switch (newState){
            case BirdState.Ready:
                makeBirdReady();
                break;
            case BirdState.Away:
                makeBirdAway();
                break;
            case BirdState.LootReady:
                break;
            case BirdState.BeingPetted:
                break;
            case BirdState.BeingTrained:
                break;
        }

        OnBirdStateChanged?.Invoke(newState);
    }
        
    private void makeBirdReady(){
        //TempBirdController.showBird();
    }

    private void makeBirdAway(){
        //TempBirdController.hideBird();
    }
}


public enum BirdState {
    Ready,
    Away,
    LootReady,
    BeingPetted,
    BeingTrained
}
