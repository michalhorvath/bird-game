using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdTimerTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BirdTimerText;

    void Start()
    {
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        hideTimer();
    }

    void OnDestroy()
    {
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    void Update()
    {
        
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
        BirdTimerText.text = "";
    }

    private void startTimer(){
        BirdTimerText.text = "12:34";
        initTimer();
    }

    private void initTimer(){
        DateTimeOffset birdArrivalTime = PlayerDataManager.Instance.playerData.birdArrivalTime;
        double seconds = (birdArrivalTime - DateTimeOffset.Now).TotalSeconds;
        StartCoroutine(timerCountdownCoroutine(seconds));
    }

    private IEnumerator timerCountdownCoroutine(double seconds){
        while(seconds > 0){
            BirdTimerText.text = $"{seconds / 60:00}:{seconds % 60:00}";
            yield return new WaitForSeconds(1f);
            seconds--;
        }
    }
}
