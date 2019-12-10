using UnityEngine;

[System.Serializable]
public class EarthquakeInfo
{
    public EarthquakeAxis XAxis;
    public EarthquakeAxis ZAxis;
    public float MaxSeconds;
    public Vector3 AverageAcceleration;

    public EarthquakeInfo(EarthquakeAxis x , EarthquakeAxis z)
    {
        XAxis = x;
        ZAxis = z;
    }

}
