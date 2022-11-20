using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdTimerTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BirdTimerText;

    void Awake(){
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        hideTimer();
    }

    void Start()
    {
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
        initCountdown();
    }

    private void initCountdown(){
        DateTimeOffset birdArrivalTime = PlayerDataManager.Instance.playerData.birdArrivalTime;
        float seconds = Mathf.Floor((float)(birdArrivalTime - DateTimeOffset.Now).TotalSeconds);
        StartCoroutine(timerCountdownCoroutine(seconds));
    }

    private IEnumerator timerCountdownCoroutine(float seconds){
        while(seconds > 0){
            BirdTimerText.text = $"{Mathf.Floor(seconds / 60):00}:{Mathf.Floor(seconds % 60):00}";
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        if (BirdTimerText.text != "") {
            BirdTimerText.text = "00:00";
        }
    }
}
