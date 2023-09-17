using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RGBColor
{
    public bool R;
    public bool G;
    public bool B;

    bool[] rgb = new bool[3];

    public RGBColor()
    {
        this.Set(false, false, false);
    }
    public RGBColor(bool r, bool g, bool b)
    {
        this.Set(r, g, b);
    }

    public void Set(bool r, bool g, bool b)
    {
        this.R = r;
        this.G = g;
        this.B = b;

        rgb[0] = this.R;
        rgb[1] = this.G;
        rgb[2] = this.B;
    }

    public void Set(RGBColor color)
    {
        this.Set(color.R, color.G, color.B);
    }

    public bool isWhite() => (R && G && B); 
    public bool isBlack() => (!R && !G && !B);

    public static RGBColor AND(RGBColor a, RGBColor b)
    {
        bool _r = false;
        bool _g = false;
        bool _b = false;

        if (a.R && b.R) _r = true;
        if (a.G && b.G) _g = true;
        if (a.B && b.B) _b = true;

        return new RGBColor(_r, _g, _b);
    }
    public static RGBColor OR(RGBColor a, RGBColor b)
    {
        bool _r = false;
        bool _g = false;
        bool _b = false;

        if (a.R || b.R) _r = true;
        if (a.G || b.G) _g = true;
        if (a.B || b.B) _b = true;

        return new RGBColor(_r, _g, _b);
    }
}
