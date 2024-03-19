using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    /*[SerializeField] private GameObject leftTeleportation;
    [SerializeField] private GameObject rightTeleportation;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;

    private void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }

    */
    [SerializeField] private GameObject leftTeleportation;
    [SerializeField] private GameObject rightTeleportation;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;
    
    //[SerializeField] private InputActionProperty leftCancel;
    //[SerializeField] private InputActionProperty rightCancel;

    [SerializeField] private XRRayInteractor leftRay;
    [SerializeField] private XRRayInteractor rightRay;

    private bool isLeftRayHovering_ = false;
    private bool isRightRayHovering_ = false;


    private void Update()
    {
        isLeftRayHovering_ = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber,
            out bool leftValue);
        leftTeleportation.SetActive(!isLeftRayHovering_ /*&& leftCancel.action.ReadValue<float>() == 0*/ && leftActivate.action.ReadValue<float>() > 0.1f);
        
        isRightRayHovering_ = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber,
            out bool rightValue);
        rightTeleportation.SetActive(!isRightRayHovering_ /*&& rightCancel.action.ReadValue<float>() == 0*/ && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
