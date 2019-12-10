using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public Text TotalTime;
    public Text ElapsedTime;
    private float _timer;

    private void Start()
    {
        EarthquakeManager.Instance.OnEarthquakeChange.AddListener(
            delegate { OnEqChange(); }
        );

        EarthquakeManager.Instance.OnEarthquakeStop.AddListener(
            delegate { OnEqStop(); }
            );
    }

    private void FixedUpdate()
    {
        if (EarthquakeManager.Instance.IsSimulating)
        {
            _timer += Time.fixedDeltaTime;
            ElapsedTime.text = _timer.ToString("0.00");
        }
    }

    private void OnEqStop()
    {
        ResetProgress();
    }

    private void OnEqChange()
    {
        ResetProgress();
        TotalTime.text = EarthquakeManager.Instance.ReturnCurrentEarthquakeInfo().MaxSeconds.ToString();
    }

    private void ResetProgress()
    {
        ElapsedTime.text = "0";
        _timer = 0;
    }
}
