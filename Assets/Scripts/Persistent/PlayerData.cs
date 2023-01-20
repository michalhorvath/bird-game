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

    public PlayerData(){
        this.coins = 0;
        this.gems = 0;
        this.birdArrivalTime = DateTimeOffset.MinValue;
        this.birdState = BirdState.Ready;
    }
}
