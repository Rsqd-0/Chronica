using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TriggerEvents : MonoBehaviour
{
    private TutoManager tutoManager;


    private void Awake()
    {
        tutoManager = FindObjectOfType<TutoManager>();
    }
    
    
    public void OnTriggerEnter(Collider other)
    {
        //if (!other.GetComponentInChildren<XROrigin>()) return;
        
        if (tutoManager.GetIndex() == 1 && tutoManager.HasTeleport()) tutoManager.SwitchPopUp();
        if (tutoManager.GetIndex() == 3 && tutoManager.HasMove()) tutoManager.SwitchPopUp();
    }

    public void OnTriggerStay(Collider other)
    {
        if (tutoManager.GetIndex() == 7) SceneManager.LoadScene("GAME");
    }
}
