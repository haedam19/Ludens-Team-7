using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLocation : MonoBehaviour
{
    public Transform PlayerTransform;

    public void Init()
    {
        transform.position = PlayerTransform.position;
    }
}
