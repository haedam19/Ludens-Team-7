using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_Object : ObjectClass
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

        UpdateDisplayColor(255);
    }
}
