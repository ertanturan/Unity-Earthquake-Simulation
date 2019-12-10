using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : ButtonComponent
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        EarthquakeManager.Instance.StopEarthquake();
    }
}
