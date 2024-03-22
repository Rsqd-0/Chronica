using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject settings;
    private void Start()
    {
        ReturntoTitle();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GAME");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    public void ToControls()
    {
        titleScreen.SetActive(false);
        settings.SetActive(false);
        controls.SetActive(true);
    }

    public void ToSettings()
    {
        titleScreen.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(true);
    }
    public void ReturntoTitle()
    {
        controls.SetActive(false);
        settings.SetActive(true);
        titleScreen.SetActive(true);

    }
}
