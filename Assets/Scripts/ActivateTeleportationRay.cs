using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleportation;
    [SerializeField] private GameObject rightTeleportation;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;

    [SerializeField] private XRRayInteractor leftRay;
    [SerializeField] private XRRayInteractor rightRay;
        
    [SerializeField] private XRDirectInteractor leftDirectRay;
    [SerializeField] private XRDirectInteractor rightDirectRay;

    private bool isLeftRayHovering_ = false;
    private bool isRightRayHovering_ = false;


    private void Update()
    {
        isLeftRayHovering_ = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber,
            out bool leftValue);
        leftTeleportation.SetActive(!isLeftRayHovering_ && leftActivate.action.ReadValue<float>() > 0.1f && leftDirectRay.interactablesSelected.Count == 0);
        
        isRightRayHovering_ = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber,
            out bool rightValue);
        rightTeleportation.SetActive(!isRightRayHovering_ && rightActivate.action.ReadValue<float>() > 0.1f && rightDirectRay.interactablesSelected.Count == 0);
    }
}