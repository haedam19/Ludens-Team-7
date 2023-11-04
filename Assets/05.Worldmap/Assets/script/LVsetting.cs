using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVsetting : MonoBehaviour
{
    public unlock_or_activate state_info;
    public Store store;

    // Start is called before the first frame update
    
    public void LV_check()
    {
        string state = state_info.GetState();
        int stage = store.GetStage();
        if (state == "activate")
        {
            store.SetLV(stage);
        }
    }
}
