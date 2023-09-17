using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    bool redlight;
    bool greenlight;
    bool bluelight;

    public Light2D backLight;

    [SerializeField] Image redBtn_img;
    [SerializeField] Image greenBtn_img;
    [SerializeField] Image blueBtn_img;

    Color redBtn_color = new Color(170, 0, 0);
    Color greenBtn_color = new Color(0, 170, 0);
    Color blueBtn_color = new Color(0, 0, 170);
    Color disabledBtn_color = Color.white;

    void Awake()
    {
        redlight = false;
        greenlight = false;
        bluelight = false;
    }

    void Update()
    {
        UpdateLight();
        UpdateButtonUI();
    }

    private void UpdateLight()
    {
        int _r = redlight ? 100 : 0;
        int _g = greenlight ? 100 : 0;
        int _b = bluelight ? 100 : 0;

        backLight.color = new Color( _r, _g, _b );
    }

    private void UpdateButtonUI()
    {
        redBtn_img.color = redlight ? redBtn_color : disabledBtn_color;
        greenBtn_img.color = greenlight ? greenBtn_color : disabledBtn_color;
        blueBtn_img.color = bluelight ? blueBtn_color : disabledBtn_color;
    }

    public void SwitchRedLight() => redlight = !redlight;
    public void SwitchGreenLight() => greenlight = !greenlight;
    public void SwitchBlueLight() => bluelight = !bluelight;

    public bool Redlight => redlight;
    public bool Greenlight => greenlight;
    public bool Bluelight => bluelight;
}
