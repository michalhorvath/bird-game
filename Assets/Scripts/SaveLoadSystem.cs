using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem
{
    private static string playerDataPath = Application.dataPath + "/PlayerData.json";
    private static string debugLogPath = Application.dataPath + "/debug.log";


    public static void savePlayerData(PlayerData playerData){
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(playerDataPath, json);
    }

    public static PlayerData loadPlayerData(){
        if (!File.Exists(playerDataPath)) {
            return null;
        }

        try
        {
            string json = File.ReadAllText(playerDataPath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            return playerData;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load", debugLogPath);
            return null;
        }
    }
}
