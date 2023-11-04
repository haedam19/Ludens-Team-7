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
            //���� �� �̵�
            SceneManager.LoadScene(1); //�׽�Ʈ�� ���� �� �ٽ� �ε�
        }
    }
}
