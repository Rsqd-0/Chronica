using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TutoManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> popUps;
    [SerializeField] private List<GameObject> popUpObj;
    private int popUpsIndex_ = 0;

    private bool hasTeleport = false;
    private bool hasMove = false;
    
    [SerializeField] private InputActionProperty showButton; // Menu
    [SerializeField] private InputActionProperty leftTeleportButton; // Teleportation
    [SerializeField] private InputActionProperty rightTeleportButton; // Teleportation
    [SerializeField] private InputActionProperty moveButton; // Move
    [SerializeField] private InputActionProperty rotateButton; // Rotate
    [SerializeField] private XRDirectInteractor leftDirectRay; // Grab
    [SerializeField] private XRDirectInteractor rightDirectRay; // Grab

    private void Start()
    {
        popUps[0].SetActive(true);

        for (int i = 1; i < popUps.Count; i++)
        {
            popUps[i].SetActive(false);
        }
    }


    private void Update()
    {
        Debug.Log(popUpsIndex_);
        switch (popUpsIndex_)
        {
            /*
             * Case 0 : Close a UI Window
             * SwitchPopUp appelé quand le joueur a cliqué sur le bouton close
             */
            
            case 1: // Teleportation
                if (leftTeleportButton.action.WasPressedThisFrame() || rightTeleportButton.action.WasPressedThisFrame()) hasTeleport = true;
                break;
            
            case 2: // Rotation
                if (rotateButton.action.WasPerformedThisFrame()) SwitchPopUp();
                break;
            
            case 3: // Move
                if (moveButton.action.WasPerformedThisFrame()) SwitchPopUp();
                break;
            
            /*
             * Case 4 : Open the UI when the player is closed enough of the object
             * SwitchPopUp appelé quand le joueur a cliqué sur le bouton close
             */
            
            case 5: // Grab an object
                if (leftDirectRay.interactablesSelected.Count != 0 || leftDirectRay.interactablesSelected.Count != 0) SwitchPopUp();
                break;
            
            case 6: // Open the menu
                if (showButton.action.WasPerformedThisFrame()) SwitchPopUp();
                break;
            
            /*
             * Case 7 : doit se rendre sur une platforme pour commencer le jeu (quand la box sera trigger,
             * le joueur changera de scène)
             */
        }
    }


    public void SwitchPopUp()
    {
        popUpsIndex_++;
        popUps[popUpsIndex_ - 1].SetActive(false);
        popUps[popUpsIndex_].SetActive(true);
        popUpObj[popUpsIndex_].SetActive(true);
    }

    public int GetIndex()
    {
        return popUpsIndex_;
    }
    
    public bool HasTeleport()
    {
        return hasTeleport;
    }
    
    public bool HasMove()
    {
        return hasMove;
    }
}
