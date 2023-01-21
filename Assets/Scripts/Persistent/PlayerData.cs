using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int coins;
    public int gems;

    [SerializeField] private long _birdArrivalTime;
    public DateTimeOffset birdArrivalTime {
        get {
            return DateTimeOffset.FromUnixTimeMilliseconds(_birdArrivalTime);
        }
        set {
            _birdArrivalTime = value.ToUnixTimeMilliseconds();
        }
    }

    public BirdState birdState;

    public int activeBirdID;
    public BirdData[] birdData;
    
    public ItemData[] itemData;

    public PlayerData(){
        this.coins = 0;
        this.gems = 0;
        this.birdArrivalTime = DateTimeOffset.MinValue;
        this.birdState = BirdState.Ready;

        this.activeBirdID = 0;
        this.birdData = new BirdData[5];
        for(int i = 0; i < birdData.Length;  i++){
            birdData[i] = new BirdData();
            birdData[i].id = i;
        }

        this.itemData = new ItemData[5];
        for(int i = 0; i < itemData.Length;  i++){
            itemData[i] = new ItemData();
            itemData[i].id = i;
        }
    }
}
