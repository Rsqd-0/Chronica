using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    [SerializeField] private GameObject window;
    private Text buttonText;

    void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        buttonText.text = window.activeSelf ? "Fermer" : "Ouvrir";
    }
    
    public void Toggle()
    {
        window.SetActive(!window.activeSelf);
    }
}
