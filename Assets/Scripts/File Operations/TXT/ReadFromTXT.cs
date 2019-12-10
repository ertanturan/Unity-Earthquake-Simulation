using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReadFromTXT
{


    //private static string Name;
    //private static string Directory;
    private static string[] _lines;
    private static float[] _seconds;
    private static float[] _acceleration;


    //public static void Init(string name)
    //{
    //    Name = name;
    //}

    public static EarthquakeInfo ReturnEarthquakeInfo(TextAsset X,TextAsset Z)
    {
        return new EarthquakeInfo(ReturnAxis(X),
            ReturnAxis(Z)
            );
    }

    private static EarthquakeAxis ReturnAxis(TextAsset ta)
    {

        TextAsset TextAsset = ta;

        _lines = TextAsset.text.Split('\n');

        _seconds = new float[_lines.Length];
        _acceleration = new float[_lines.Length];

        for (int i = 0; i < _lines.Length; i++)
        {
            string[] commaSplit = _lines[i].Split(',');
            _seconds[i] = float.Parse(commaSplit[0]);
            _acceleration[i] = float.Parse(commaSplit[1]);
        }

        return new EarthquakeAxis(_seconds, _acceleration);
    }




}


