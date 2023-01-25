using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    public ParticleSystem smoke;

    void Awake(){
        smoke.Stop();
    }

    void Start(){
        StartCoroutine(LateStart(3));
    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        BirdManager.OnActiveBirdChanged += OnActiveBirdChanged;
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
    }

    void OnDestroy(){
        BirdManager.OnActiveBirdChanged -= OnActiveBirdChanged;
    }

    private void OnActiveBirdChanged(int activeBirdID){
        play();
    }

    private void OnBirdStateChanged(BirdState birdState){
        if (birdState == BirdState.Out || birdState == BirdState.GotLoot){
            play();
        }
    }

    private void play(){
        smoke.Clear();
        smoke.Play();
    }
}
