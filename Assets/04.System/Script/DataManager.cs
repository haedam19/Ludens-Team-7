using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//https://coding-of-today.tistory.com/178

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public TestPlayerData nowPlayer = new TestPlayerData();
    public int nowSlot;
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
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<TestPlayerData>(data);
    }
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new TestPlayerData();
    }
}
