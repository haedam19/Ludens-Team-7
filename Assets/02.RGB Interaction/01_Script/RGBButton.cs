using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBButton : MonoBehaviour
{
    [SerializeField] private LightManager lightManager;

    [SerializeField] private bool activated;

    [SerializeField] private bool leverR;
    [SerializeField] private bool leverG;
    [SerializeField] private bool leverB;

    [SerializeField] private float activationTime;

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

    public void Interact()
    {
        if(!activated)
        {
            activated = true;

            StartCoroutine(Activate());

            SwitchLights();
        }
    }
}
