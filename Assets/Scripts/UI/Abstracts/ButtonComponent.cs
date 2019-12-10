using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonComponent : MonoBehaviour
{
    private Button _button;
    protected UnityAction OnButtonClickAction;

    public virtual void Awake()
    {
        _button = GetComponent<Button>();
        OnButtonClickAction += OnButtonClick;
        _button.onClick.AddListener(OnButtonClickAction);
    }

    public virtual void OnButtonClick()
    {

    }
}
