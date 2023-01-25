using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Material bird0;
    public Material bird1;
    public Material bird2;
    public Material bird3;
    public Material bird4;

    void Awake(){
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
        BirdManager.OnActiveBirdChanged += OnActiveBirdChanged;
        showBird();
    }
    
    void Start(){
    }

    void OnDestroy(){
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
        BirdManager.OnActiveBirdChanged -= OnActiveBirdChanged;
    }

    void Update(){
        
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                showBird();
                break;
            case BirdState.Out:
                hideBird();
                break;
            case BirdState.GotLoot:
                showBird();
                break;
        }
    }

    private void OnActiveBirdChanged(int activeBirdID){
        switch (activeBirdID){
            case 0:
                GetComponent<MeshRenderer>().material = bird0;
                break;
            case 1:
                GetComponent<MeshRenderer>().material = bird1;
                break;
            case 2:
                GetComponent<MeshRenderer>().material = bird2;
                break;
            case 3:
                GetComponent<MeshRenderer>().material = bird3;
                break;
            case 4:
                GetComponent<MeshRenderer>().material = bird4;
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
