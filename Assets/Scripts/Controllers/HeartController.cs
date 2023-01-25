using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public ParticleSystem heart;

    void Awake(){
        heart.Stop();
    }

    void Start(){
        StartCoroutine(LateStart(3));
    }

    IEnumerator LateStart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        BirdManager.OnBirdPetted += OnBirdPetted;
    }

    void OnDestroy(){
        BirdManager.OnBirdPetted -= OnBirdPetted;
    }

    private void OnBirdPetted(string ignore){
        play();
    }


    private void play(){
        heart.Clear();
        heart.Play();
    }
}
