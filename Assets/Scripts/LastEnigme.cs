using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnigme : MonoBehaviour
{
    [SerializeField] private Material red;
    private Renderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Poinçon"))
        {
            Debug.Log("done");
            meshRenderer.material = red;
        }
    }
}
