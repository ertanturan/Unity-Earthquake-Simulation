using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSeverityDropdown : DropDownComponent
{
    private void Start()
    {
        EarthquakeManager.Instance.OnEarthquakeStart.AddListener(
            delegate { OnEqStart(); }
        );
        EarthquakeManager.Instance.OnEarthquakePause.AddListener(
            delegate { OnEqPause(); }
        );

        EarthquakeManager.Instance.OnEarthquakeContinue.AddListener(
            delegate { OnEqContinue(); }
        );

        EarthquakeManager.Instance.OnEarthquakeStop.AddListener(
            delegate { OnEqStop(); }
        );

    }

    public override void OnValue()
    {
        base.OnValue();

        switch (DropDown.value)
        {
            case 0:
                Debug.Log("LIGHT EQ SELECTED..");
                EarthquakeManager.Instance.SetEarthquake(EarthquakeType.Light);
                break;
            case 1:
                Debug.Log("STRONG EQ SELECTED..");
                EarthquakeManager.Instance.SetEarthquake(EarthquakeType.Strong);
                break;
        }
    }

    private void OnEqStart()
    {
        DropDown.interactable = false;
    }

    private void OnEqPause()
    {
        DropDown.interactable = false;
    }

    private void OnEqContinue()
    {
        DropDown.interactable = true;
    }

    private void OnEqStop()
    {
        DropDown.interactable = true;
    }


}
