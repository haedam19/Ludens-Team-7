using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] protected LightManager lightManager;

    [SerializeField] protected bool activated;

    [SerializeField] protected bool leverR;
    [SerializeField] protected bool leverG;
    [SerializeField] protected bool leverB;

    protected SpriteRenderer rend;
    protected Light2D activationLight;

    protected virtual void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        activationLight = GetComponentInChildren<Light2D>();
        SetColor();

        activationLight.enabled = activated;
    }
    protected void SetColor()
    {
        int _r = leverR ? 100 : 0;
        int _g = leverG ? 100 : 0;
        int _b = leverB ? 100 : 0;

        rend.color = new Color(_r, _g, _b);
        //activationLight.color = new Color(_r, _g, _b);
    }

    public virtual void Interact()
    {
    }
}
