using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    
    void Start()
    {
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;     
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
        transform.position += new Vector3(1000f, 0.0f);
    }

    private void hideBird(){
        transform.position += new Vector3(-1000f, 0.0f);
    }
}
