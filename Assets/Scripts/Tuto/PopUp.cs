using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private TutoManager tutoManager;


    private void Awake()
    {
        tutoManager = FindObjectOfType<TutoManager>();
    }


    public void Close0()
    {
        GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        tutoManager.SwitchPopUp();
    }
    
    public void Close()
    {
        GetComponentInChildren<Canvas>().gameObject.SetActive(false);
    }

    public void Open4()
    {
        tutoManager.SwitchPopUp();
    }
}
