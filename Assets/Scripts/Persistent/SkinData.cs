using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SkinData
{
    public int id;
    public bool isBought;

    public SkinData(){
        this.id = -1;
        this.isBought = false;
    }
}
