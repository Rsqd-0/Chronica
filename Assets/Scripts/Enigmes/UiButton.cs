using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    public GameObject ui = null;
    public GameObject window = null;
    
    
    public void Close()
    {
        ui.SetActive(true);
        window.SetActive(false);
    }

    public void Open()
    {
        Debug.Log("open");
        ui.SetActive(false);
        window.SetActive(true);
    }
}
