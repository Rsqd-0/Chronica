using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    [SerializeField] private GameObject pageContentFront;
    [SerializeField] private GameObject pageContentBack;
    

    public void Update()
    {
        if (transform.rotation.y < - 0.5f)
        {
            pageContentFront.SetActive(false);
            pageContentBack.SetActive(true);
        }
        else
        {
            pageContentFront.SetActive(true);
            pageContentBack.SetActive(false);
        }
    }
}