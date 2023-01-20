using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static event Action<string> OnLootCollected;

    public static LootManager Instance;

    void Awake(){
        Instance = this;
    }

    void Start(){
    }

    void OnDestroy(){
    }

    void Update(){
    }

    public void getLoot(){
        PlayerDataManager.coins += 100;
        OnLootCollected?.Invoke("ignore");
    }

}
