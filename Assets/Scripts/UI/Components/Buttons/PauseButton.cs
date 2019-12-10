using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : ButtonComponent
{
    private Text _buttonText;

    public override void Awake()
    {
        base.Awake();
        _buttonText = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        EarthquakeManager.Instance.OnEarthquakeChange.AddListener(
            delegate { OnEqChange(); }
        );

        EarthquakeManager.Instance.OnEarthquakeStop.AddListener(
            delegate { OnEqStop(); }
        );

        EarthquakeManager.Instance.OnEarthquakePause.AddListener(
            delegate { OnEqPause(); }
        );

        EarthquakeManager.Instance.OnEarthquakeContinue.AddListener(
            delegate { OnEQContinue(); }
        );


    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();

        if (EarthquakeManager.Instance.IsSimulating)
        {
            EarthquakeManager.Instance.PauseEarthquake();
        }
        else
        {
            EarthquakeManager.Instance.ContinueEarthquake();
        }
    }

    private void OnEqStop()
    {
        _buttonText.text = "PAUSE";
    }

    private void OnEqChange()
    {

        _buttonText.text = "PAUSE";
    }

    private void OnEqPause()
    {
        _buttonText.text = "CONTINUE";
    }

    private void OnEQContinue()
    {
        _buttonText.text = "PAUSE";
    }

}
