using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVsetting : MonoBehaviour
{
    public Store store;

    public void LV_check()
    {
        string state = GetComponent<Unlock_or_activate>().GetState();
        int stage = store.GetStage();
        if (state.Equals("activate") || state.Equals("unlocked"))
        {
            store.Save();
            //게임 씬 이동
            SceneManager.LoadScene(1); //테스트로 현재 맵 다시 로드
        }
    }
}
