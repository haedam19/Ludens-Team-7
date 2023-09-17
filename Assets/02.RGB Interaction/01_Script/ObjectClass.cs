using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectClass : MonoBehaviour
{
    [SerializeField] protected LightManager lightManager;

    [SerializeField] protected bool objectR;
    [SerializeField] protected bool objectG;
    [SerializeField] protected bool objectB;

    protected RGBColor objectRGB;
    protected RGBColor displayRGB;
    protected RGBColor lightRGB;

    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        objectRGB = new RGBColor(objectR, objectG, objectB);
        lightRGB = new RGBColor();
        displayRGB = new RGBColor();
    }

    protected virtual void Update()
    {
        UpdateLightColor();
        SetRGBColors();
    }
    protected virtual void CheckLightInteraction() { }

    protected void UpdateDisplayColor(int alpha)
    {
        int _r = displayRGB.R ? 100 : 0;
        int _g = displayRGB.G ? 100 : 0;
        int _b = displayRGB.B ? 100 : 0;

        spriteRenderer.color = new Color(_r, _g, _b, alpha);
    }

    protected void UpdateLightColor()
    {
        lightRGB.R = lightManager.Redlight;
        lightRGB.G = lightManager.Greenlight;
        lightRGB.B = lightManager.Bluelight;
    }

    protected void SetRGBColors()
    {
        objectRGB.Set(objectR, objectG, objectB);
    }

}
