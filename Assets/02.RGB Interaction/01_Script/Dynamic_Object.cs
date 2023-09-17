using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic_Object : ObjectClass
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
        displayRGB.Set(RGBColor.OR(objectRGB, lightRGB));

        UpdateDisplayColor(255);
    }
}
