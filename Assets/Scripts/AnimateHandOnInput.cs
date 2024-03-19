using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHandOnInput : MonoBehaviour
{
    //[SerializeField] private InputActionProperty pinchAnimationAction;
    [SerializeField] private InputActionProperty gripAnimationAction;
    [SerializeField] private Animator handAnimator;

    //private float triggerValue;
    private float gripValue;


    private void Update()
    {
        //triggerValue = pinchAnimationAction.action.ReadValue<float>();
        //handAnimator.SetFloat("Trigger", triggerValue);
        
        gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
