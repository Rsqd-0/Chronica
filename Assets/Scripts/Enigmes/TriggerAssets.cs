using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAssets : MonoBehaviour
{
    private GameObject canvas = null;
    private UiButton uiButtonScript = null;


    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>().gameObject;
        uiButtonScript = canvas.GetComponent<UiButton>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.gameObject.GetComponentInChildren<XROrigin>())
        {
            canvas.SetActive(true);   
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
        if (other.gameObject.GetComponentInChildren<XROrigin>())
        {
            uiButtonScript.window.SetActive(false);
            uiButtonScript.ui.SetActive(true);
            canvas.SetActive(false);
        }
    }

}
