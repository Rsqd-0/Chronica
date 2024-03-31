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
        
        canvas.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<XROrigin>())
        {
            canvas.SetActive(true); 
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Book book))
        {
            Wait(book);
            return;
        }
        
        
        if (other.gameObject.GetComponentInChildren<XROrigin>())
        {
            uiButtonScript.window.SetActive(false);
            uiButtonScript.ui.SetActive(true);
            canvas.SetActive(false);
        }
    }


    private IEnumerator Wait(Book book)
    {
        /*while (book.GetIsRotating())
        {
            yield return null;
        }*/
        
        uiButtonScript.window.SetActive(false);
        uiButtonScript.ui.SetActive(true);
        canvas.SetActive(false);
        yield return null;
    }

}
