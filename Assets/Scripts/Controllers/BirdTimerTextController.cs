using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdTimerTextController : MonoBehaviour
{
    private UIDocument document;
    private Label homeBirdTimer;

    void Awake(){
        document = GetComponent<UIDocument>();
        homeBirdTimer = document.rootVisualElement.Q<Label>("HomeBirdTimer");

        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        hideTimer();
    }

    void OnDestroy()
    {
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                hideTimer();
                break;
            case BirdState.Out:
                startTimer();
                break;
        }
    }

    private void hideTimer(){
        homeBirdTimer.text = "";
    }

    private void startTimer(){
        initCountdown();
    }

    private void initCountdown(){
        DateTimeOffset birdArrivalTime = PlayerDataManager.Instance.playerData.birdArrivalTime;
        float seconds = Mathf.Floor((float)(birdArrivalTime - DateTimeOffset.Now).TotalSeconds);
        StartCoroutine(timerCountdownCoroutine(seconds));
    }

    private IEnumerator timerCountdownCoroutine(float seconds){
        while(seconds > 0){
            homeBirdTimer.text = $"{Mathf.Floor(seconds / 60):00}:{Mathf.Floor(seconds % 60):00}";
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        if (homeBirdTimer.text != "") {
            homeBirdTimer.text = "00:00";
        }
    }
}
