using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;


public class Enigme2 : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyBoard());
    }


    public void OpenKeyBoard()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(NonNativeKeyboard.Instance.InputField.text);
    }
}
