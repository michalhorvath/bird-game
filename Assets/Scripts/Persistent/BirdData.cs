using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BirdData
{
    public int id;
    public bool isBought;

    public int speed;
    public int wisdom;
    public int greed;

    public BirdData(){
        this.id = -1;
        this.isBought = false;

        this.speed = 0;
        this.wisdom = 0;
        this.greed = 0;
    }
}
