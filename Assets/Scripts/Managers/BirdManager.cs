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
                break;
            case BirdState.Away:
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
}

public enum BirdState {
    Ready,
    Away,
    LootReady,
    BeingPetted,
    BeingTrained
}
