using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BirdData
{
    public int id;
    public bool isBought;

    public int[] skills; 

    public BirdData(){
        this.id = -1;
        this.isBought = false;

        this.skills = new int[]{0, 0, 0}; 
    }
}
