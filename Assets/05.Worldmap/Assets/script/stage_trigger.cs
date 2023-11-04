using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class stage_trigger : MonoBehaviour
{
    public int stage_number;
    public GameObject stageUI; // Inspector에서 할당. TextMesh Pro 텍스트와 버튼을 포함하는 부모 오브젝트
    public Store store;  // 인스펙터에서 Store 컴포넌트를 할당

    public PlayerLocation playerLocation;
    public Unlock_or_activate uoa;

    private void Awake()
    {
        playerLocation.OnTransformPlayerToGate.AddListener(Test_OnTransformPlayerToGate);
    }

    private void Test_OnTransformPlayerToGate(Transform PlayerTransform)
    {
        if (store != null && stage_number.Equals(store.GetStage()))
        {
            PlayerTransform.position = transform.position + new Vector3(0, -1, 0);
            CamaraLocation camaraLocation = FindObjectOfType<CamaraLocation>();
            camaraLocation.Init();
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            store.SetStage(stage_number);
            store.SetTitle("stage " + stage_number.ToString());
            uoa.InitTitle();
            stageUI.SetActive(true); // UI 표시
        }
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stageUI.SetActive(false); // UI 숨김
        }
    }
}
