using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : ButtonComponent
{
    public override void OnButtonClick()
    {
        base.OnButtonClick();
        EarthquakeManager.Instance.StartEarthquake();
    }
}
