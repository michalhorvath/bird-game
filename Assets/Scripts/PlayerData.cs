using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int coins;
    public DateTimeOffset birdArrivalTime;

    public PlayerData(){
        this.coins = 0;
        this.birdArrivalTime = DateTimeOffset.MinValue;
    }
}
