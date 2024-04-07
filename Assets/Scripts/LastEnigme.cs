using System;
using System.Collections;
using System.Collections.Generic;
using Enigmes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastEnigme : MonoBehaviour
{
    [SerializeField] private EnigmeManager enigme;
    [SerializeField] private Material red;
    [SerializeField] private GameObject fresque;
    private Renderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Poinçon"))
        {
            enigme.Success();
            meshRenderer.material = red;
            StartCoroutine(Wait());
        }
    }

    private void Update()
    {
        if (EnigmeManager.EnigmeNum == 3)
        {
            fresque.SetActive(true);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
