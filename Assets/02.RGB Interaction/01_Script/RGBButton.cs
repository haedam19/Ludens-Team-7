using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBButton : InteractionObject
{
    [SerializeField] private float activationTime;

    protected override void Awake()
    {
        base.Awake();
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

    IEnumerator Activate()
    {
        transform.GetChild(0).localPosition = new Vector3(0, -0.2f, 0);
        activationLight.enabled = true;

        yield return new WaitForSeconds(activationTime);

        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        activationLight.enabled = false;
        activated = false;

        SwitchLights();
    }

    public override void Interact()
    {
        if(!activated)
        {
            activated = true;

            StartCoroutine(Activate());

            SwitchLights();
        }
    }
}
