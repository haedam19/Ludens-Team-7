using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBLever : InteractionObject
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Activate()
    {
        if(activated)
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
            activationLight.enabled = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
            activationLight.enabled = false;
        }
    }

    private void SwitchLights()
    {
        if(leverR)
        {
            lightManager.SwitchRedLight();
        }
        if(leverG)
        {
            lightManager.SwitchGreenLight();
        }
        if(leverB)
        {
            lightManager.SwitchBlueLight();
        }
    }

    public override void Interact()
    {
        activated = !activated;
        Activate();

        SwitchLights();
    }
}
