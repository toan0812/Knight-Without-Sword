using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";

    public static void SaveData(PlayerData playerData)
    {
        string dir = Application.persistentDataPath + directory;
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(dir+ fileName, json);
    }
    public static PlayerData LoadData()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        PlayerData playerData = new PlayerData();
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogError("Save file dosen't exist");
        }
        return playerData;
    }
}
