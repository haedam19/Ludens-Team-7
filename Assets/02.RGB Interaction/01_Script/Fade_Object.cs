using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Object : ObjectClass
{
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        CheckLightInteraction();
    }

    protected override void CheckLightInteraction()
    {
        if(objectRGB.isWhite())
        {
            displayRGB.Set(lightRGB);
        }
        else
        {
            displayRGB.Set(RGBColor.AND(objectRGB, lightRGB));
        }

        if(RGBColor.AND(objectRGB, lightRGB).isBlack())
        {
            UpdateDisplayColor(0);
        }
        else
        {
            UpdateDisplayColor(255);
        }
    }
}
