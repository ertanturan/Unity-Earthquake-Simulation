using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EarthquakeAxis 
{
    public float[] Seconds;
    public float[] Acceleration;

    public EarthquakeAxis(float[] seconds, float[] acc)
    {
        Seconds = seconds;
        Acceleration = acc;
    }
}
