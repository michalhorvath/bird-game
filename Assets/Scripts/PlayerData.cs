using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int coins;

    [SerializeField] private long _birdArrivalTime;
    public DateTimeOffset birdArrivalTime {
        get {
            return DateTimeOffset.FromUnixTimeMilliseconds(_birdArrivalTime);
        }
        set {
            _birdArrivalTime = value.ToUnixTimeMilliseconds();
        }
    }

    public PlayerData(){
        this.coins = 0;
        this.birdArrivalTime = DateTimeOffset.MinValue;
    }
}
