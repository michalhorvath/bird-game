using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdTimerTextController : MonoBehaviour
{
    private UIDocument document;
    private Label homeBirdTimer;

    private bool isRunning;

    void Awake(){
        document = GetComponent<UIDocument>();
        homeBirdTimer = document.rootVisualElement.Q<Label>("HomeBirdTimer");

        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        stopTimer();
    }

    void OnDestroy() {
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    void Update() {
        if (isRunning) {
            DateTimeOffset birdArrivalTime = PlayerDataManager.birdArrivalTime;
            float seconds = Mathf.Floor((float)(birdArrivalTime - DateTimeOffset.Now).TotalSeconds);
            homeBirdTimer.text = $"{Mathf.Floor(seconds / 60):00}:{Mathf.Floor(seconds % 60):00}";
        }
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                stopTimer();
                break;
            case BirdState.Out:
                startTimer();
                break;
            case BirdState.GotLoot:
                stopTimer();
                break;
        }
    }

    private void stopTimer(){
        isRunning = false;
    }

    private void startTimer(){
        isRunning = true;
    }
}
