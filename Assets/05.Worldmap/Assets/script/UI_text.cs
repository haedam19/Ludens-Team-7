using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro 네임스페이스 사용

public class UI_text : MonoBehaviour
{
    public TextMeshProUGUI textMesh;  // 인스펙터에서 TextMeshProUGUI 컴포넌트를 할당
    public Store store;  // 인스펙터에서 Store 컴포넌트를 할당

    void Start()
    {
        if (store != null && textMesh != null)
        {
            // Store 스크립트의 GetTitle 메서드를 호출하여 TextMeshPro의 텍스트 업데이트
            textMesh.text = store.GetTitle();
        }
        else
        {
            Debug.LogError("Store 또는 TextMeshProUGUI 컴포넌트가 할당되지 않았습니다.");
        }
    }

    void Update()
    {
        if (store != null && textMesh != null)
        {
            // Store 스크립트의 GetTitle 메서드를 호출하여 TextMeshPro의 텍스트 업데이트
            textMesh.text = store.GetTitle();
        }
        else
        {
            Debug.LogError("Store 또는 TextMeshProUGUI 컴포넌트가 할당되지 않았습니다.");
        }
    }
}