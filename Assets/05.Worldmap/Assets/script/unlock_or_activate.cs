using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Unlock_or_activate : MonoBehaviour
{
    public TextMeshProUGUI textMesh;  // 인스펙터에서 TextMeshProUGUI 컴포넌트를 할당
    public Store store;  // 인스펙터에서 Store 컴포넌트를 할당

    private string state = "activate";
    public void SetState(string newValue)
    {
        state = newValue;
    }

    public string GetState()
    {
        return state;
    }

    public void InitTitle()
    {
        if (store != null && textMesh != null)
        {
            int level = store.GetLV();
            int stage = store.GetStage();
            
            // 현재 위치한 스테이지가 해금되지 않았을 때
            if (stage-1 == level)
            {
                state = "activate";
                GetComponent<Button>().interactable = true;
            }
            else if (level >= stage)
            {
                state = "unlocked";
                GetComponent<Button>().interactable = true;
            }
            else
            {
                state = "locked";
                GetComponent<Button>().interactable = false;
            }
            
            textMesh.text = state;
        }
        else
        {
            Debug.LogError("Store 또는 TextMeshProUGUI 컴포넌트가 할당되지 않았습니다.");
        }
    }
}
