using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private float pageSpeed = 0.1f;
    [SerializeField] private List<Transform> pages;
    private int _index = -1;
    private bool _isRotating = false;

    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject forwardButton;


    public bool GetIsRotating()
    {
        return _isRotating;
    }
    
    
    private void Start()
    {
        backButton.SetActive(false);
    }

    public void RotateForward()
    {
        if (_index >= pages.Count || _isRotating) return;
        _index++;
        float angle = 180; // rotation of the page
        ForwardButtonAction();
        pages[_index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    private void ForwardButtonAction()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true); //every time we turn the page forward, the back button should be activated
        }
        if (_index == pages.Count - 1)
        {
            forwardButton.SetActive(false); //if the page is last then we turn off the forward button
        }
    }

    public void RotateBack()
    {
        if (_index <= -1 || _isRotating) return;
        float angle = 0;
        pages[_index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    private void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //every time we turn the page back, the forward button should be activated
        }
        if (_index - 1 == -1)
        {
            backButton.SetActive(false); //if the page is first then we turn off the back button
        }
    }

    private IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            _isRotating = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[_index].rotation = Quaternion.Slerp(pages[_index].rotation, targetRotation, value);

            // angle between the given one and the current one
            float angle1 = Quaternion.Angle(targetRotation, pages[_index].rotation);
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    _index--;
                }
                _isRotating = false;
                break;
            }
            yield return null;
        }
    }
}