using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject settings;
    [SerializeField] private Transform head;
    private void Start()
    {
        ReturntoTitle();
        var forward = head.forward;
        var position = head.position;
        titleScreen.transform.position =
            position + new Vector3(forward.x, 0.1f, forward.z).normalized * 1.5f;
        controls.transform.position =
            position + new Vector3(forward.x, 0.1f, forward.z).normalized * 1.5f;
        settings.transform.position =
            position + new Vector3(forward.x, 0.1f, forward.z).normalized * 1.5f;
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
        settings.SetActive(false);
        titleScreen.SetActive(true);

    }
}
