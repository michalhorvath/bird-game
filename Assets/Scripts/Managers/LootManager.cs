using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static event Action<string> OnLootClaimed;

    public static LootManager instance;

    private Loot nextLoot;

    private float[] bonus0 = {0f, 0.03f, 0.06f, 0.125f, 0.25f, 0.50f};
    private int[] bonus1 = {1, 2, 3, 4, 5, 6};
    private float[] bonus2 = {0f, 0.19f, 0.38f, 0.75f, 1.5f, 3f};
    private float base0 = 20f;
    private float base2 = 50f;

    void Awake(){
        instance = this;
        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
    }

    void Start(){
    }

    void OnDestroy(){
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    void Update(){
    }

    public void claimLoot(){
        PlayerDataManager.coins += nextLoot.coins;
        if (nextLoot.isDuplicit){
            PlayerDataManager.coins += 100;
        } else {
            PlayerDataManager.getItemData()[nextLoot.itemID].isFound = true;
            PlayerDataManager.Instance.playerDataChanged();
        }
        OnLootClaimed?.Invoke("ignore");
    }

    public Loot previewLoot(){
        return nextLoot;
    }

    private void generateNewLoot(){
        nextLoot = new Loot();
        nextLoot.coins = generateCoins();
        nextLoot.itemID = generateItem();
        nextLoot.isDuplicit = PlayerDataManager.getItemData()[nextLoot.itemID].isFound;
    }

    private int generateCoins(){
        return (int)(base2 + base2 * bonus2[PlayerDataManager.getActiveBird().skills[2]]);
    }

    private int generateItem(){
        ItemData[] itemData = PlayerDataManager.getItemData();

        int[] prefixSums = new int[itemData.Length];
        int last = 0;
        for(int i = 0; i<itemData.Length; i++){
            if(itemData[i].isFound){
                last += bonus1[PlayerDataManager.getActiveBird().skills[1]]-1;
            }
            prefixSums[i] = last;
            last++; 
        }

        System.Random random = new System.Random();
        int n = random.Next(0, last);
        for(int i = 0; i<itemData.Length-1; i++){
            if (prefixSums[i]<=n && n<prefixSums[i+1]){
                return i;
            }
        }
        return itemData.Length-1;
    }

    private void OnBirdStateChanged(BirdState birdState){
        generateNewLoot();
    }

    public int getOutTime(){
        return (int)(base0 - base0 * bonus0[PlayerDataManager.getActiveBird().skills[0]]);
    }
}

public struct Loot{
    public int coins;
    public int itemID;
    public bool isDuplicit;
}
