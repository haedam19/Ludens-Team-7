using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    private int stage = -1; // 현재 위치한 stage
    private string title = ""; // screen에 보일 글씨
    private int LV = -1; // 현재 해금한 스테이지 (하나도 해금하지 않았을 때, 즉 1스테이지일 때 0)

    public void Start()
    {
        if (File.Exists(DataManager.instance.path))
        {
            DataManager.instance.LoadData();
            LV = DataManager.instance.playerData.lv;
            stage = DataManager.instance.playerData.stage;
        }
        else    // 데이터가 없는 경우
        {
            Debug.LogError("데이터가 존재하지 않습니다. 레벨(진척도) 0, 스테이지(현재위치) 1 로 초기화됩니다.");
            LV = 0;
            stage = 1;
            Save();
        }
        PlayerLocation playerLocation = FindObjectOfType<PlayerLocation>();
        playerLocation.Init();
    }

    public void Save()
    {
        DataManager.instance.playerData.lv = LV;
        DataManager.instance.playerData.stage = stage;
        DataManager.instance.SaveData();
    }

    public void SetStage(int newValue)
    {
        stage = newValue;
    }

    public int GetStage()
    {
        return stage;
    }

    public void SetTitle(string newValue)
    {
        title = newValue;
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetLV(int newValue)
    {
        LV = newValue;
    }

    public int GetLV()
    {
        return LV;
    }
}
