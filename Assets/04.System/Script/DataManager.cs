using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//https://coding-of-today.tistory.com/178

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData playerData = new PlayerData();
    public string path;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/save";
        print(path);
    }
    public void SaveData()
    {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(data);
    }
    public void DataClear()
    {
        playerData = new PlayerData();
    }
    public void DeleteData()
    {
        File.Delete(path);
    }
}
