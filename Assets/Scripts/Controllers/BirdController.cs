using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    void Awake(){
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        showBird();
    }
    
    void Start()
    {
    }

    void OnDestroy(){
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    void Update()
    {
        
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                showBird();
                break;
            case BirdState.Out:
                hideBird();
                break;
        }
    }

    private void showBird(){
        gameObject.SetActive(true);
    }

    private void hideBird(){
        gameObject.SetActive(false);
    }
}
