using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] private GameObject leftGrabRay;
    [SerializeField] private GameObject rightGrabRay;

    [SerializeField] private XRDirectInteractor leftDirection;
    [SerializeField] private XRDirectInteractor rightDirection;


    private void Update()
    {
        leftGrabRay.SetActive(leftDirection.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(rightDirection.interactablesSelected.Count == 0);
    }
}
