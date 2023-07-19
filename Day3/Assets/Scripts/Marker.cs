using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public static Marker Instance;

    public string number;
    private void Awake()
    {
        Instance = this;
    }
}
