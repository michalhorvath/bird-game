using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ItemData
{
    public int id;
    public bool isFound;

    public int activeSkinID;
    public SkinData[] skinData;

    public ItemData(){
        this.id = -1;
        this.isFound = false;

        this.activeSkinID = 0;
        this.skinData = new SkinData[3];
        for(int i = 0; i < skinData.Length;  i++){
            skinData[i] = new SkinData();
            skinData[i].id = i;
        }
    }
}
