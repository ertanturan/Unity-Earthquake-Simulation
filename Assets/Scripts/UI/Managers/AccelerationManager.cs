using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationManager : MonoBehaviour
{
    public Text AverageAcceleration;

    public Text CurrentAcceleration;

    private void Start()
    {

        EarthquakeManager.Instance.OnEarthquakeChange.AddListener(
            delegate { OnEqChange(); }
            );

        EarthquakeManager.Instance.OnEarthquakeStop.AddListener(
            delegate { OnEqStop(); }
        );
    }

    private void OnEqChange()
    {
        Vector3 avgAcc = EarthquakeManager.Instance.
            ReturnCurrentEarthquakeInfo().AverageAcceleration;

        AverageAcceleration.text = VecToString(avgAcc);
    }

    private void OnEqStop()
    {
        ResetTexts();
    }

    private void ResetTexts()
    {
        AverageAcceleration.text = "0";
        CurrentAcceleration.text = "0";
    }

    private void LateUpdate()
    {
        if (EarthquakeManager.Instance.IsSimulating)
        {
            CurrentAcceleration.text = VecToString(EarthquakeManager.Instance.CurrentAcceleration);
        }
    }

    private string VecToString(Vector3 vec)
    {
        return "(" +
               vec.x.ToString("F2") + "," +
               vec.y.ToString("F2") + "," +
               vec.z.ToString("F2") + ")";
    }

}
