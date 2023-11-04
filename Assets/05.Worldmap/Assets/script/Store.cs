using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    private int stage = 1; // 현재 위치한 stage
    private string title = ""; // screen에 보일 글씨
    private int LV = 0; // 현재 해금한 스테이지 (하나도 해금하지 않았을 때, 즉 1스테이지일 때 0)

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
