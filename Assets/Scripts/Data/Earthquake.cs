using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Earthquake",menuName = "Earthquake/New Earthquake")]
public class Earthquake : ScriptableObject
{
    private const string dir = "Data/Earthquake/Data/Texts/";
    public EarthquakeType Type;
    [SerializeField]

    [Header("Text Assets")]
    public TextAsset X;
    public TextAsset Z;

    [Header("Earthquake Info")]
    public EarthquakeInfo Info;

}

public enum EarthquakeType
{
    Light=0,
    Strong=1
}

public enum EarthquakeAxisType
{
    x,
    z
}
