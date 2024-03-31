using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] List<Transform> pages;
    int index = -1;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    private void Start()
    {
        InitialState();
    }
    
    public void InitialState()
    {
        backButton.SetActive(false);

    }

    public void RotateForward()
    {
        index++;
        float angle = 0; //in order to rotate the page forward, you need to set the rotation by 180 degrees around the y axis
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true); //every time we turn the page forward, the back button should be activated
        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false); //if the page is last then we turn off the forward button
        }
    }

    public void RotateBack()
    {
        float angle = 180; //in order to rotate the page back, you need to set the rotation to 0 degrees around the y axis
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //every time we turn the page back, the forward button should be activated
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false); //if the page is first then we turn off the back button
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        while (true)
        {
            pages[index].rotation = Quaternion.Euler(0, angle, 0);
            float angle1 = Quaternion.Angle(pages[index].rotation, Quaternion.Euler(0, angle, 0)); //calculate the angle between the given angle of rotation and the current angle of rotation
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                break;

            }
            yield return null;

        }
    }



}