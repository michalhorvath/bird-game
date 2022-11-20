using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameObject getLootButton;

    public static event Action<string> OnLootCollected;

    public static LootManager instance;

    void Awake(){
        instance = this;
        hideGetLootButton();
    }

    void Start(){
    }

    void OnDestroy(){
    }

    void Update(){
    }

    public void getLoot(){
        PlayerDataManager.Instance.playerData.coins += 100;
        OnLootCollected?.Invoke("random_text");
    }

    private void hideGetLootButton(){
        getLootButton.SetActive(false);
    }
    
    private void showGetLootButton(){
        getLootButton.SetActive(true);
    }
}
