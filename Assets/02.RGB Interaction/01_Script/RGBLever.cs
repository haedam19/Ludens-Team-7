using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBLever : MonoBehaviour
{
    [SerializeField] private LightManager lightManager;

    [SerializeField] private bool activated;

    [SerializeField] private bool leverR;
    [SerializeField] private bool leverG;
    [SerializeField] private bool leverB;

    private SpriteRenderer rend;
    private Light2D activationLight;

    void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        activationLight = GetComponentInChildren<Light2D>();
        SetColor();

        activationLight.enabled = activated;
    }

    private void SetColor()
    {
        int _r = leverR ? 100 : 0;
        int _g = leverG ? 100 : 0;
        int _b = leverB ? 100 : 0;

        rend.color = new Color(_r, _g, _b);
        //activationLight.color = new Color(_r, _g, _b);
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

    public void Interact()
    {
        activated = !activated;
        Activate();

        SwitchLights();
    }
}
