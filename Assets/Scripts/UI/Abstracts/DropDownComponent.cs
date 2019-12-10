using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropDownComponent : MonoBehaviour
{
    [HideInInspector]
    public Dropdown DropDown;

    public virtual void Awake()
    {
        DropDown = GetComponent<Dropdown>();

        DropDown.onValueChanged.AddListener(
            delegate { OnValue();}
            );
    }


    public virtual void OnValue()
    {

    }

}
