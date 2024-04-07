using System.Collections;
using System.Collections.Generic;
using Enigmes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject rulesMenu;
    [SerializeField] private InputActionProperty showButton;
    [SerializeField] private Transform head;
    [SerializeField] private float spawnDistance = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        rulesMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPerformedThisFrame() && !rulesMenu.activeSelf)
        {
            menu.SetActive(!menu.activeSelf);
            rulesMenu.SetActive(false);

            var forward = head.forward;
            menu.transform.position =
                head.position + new Vector3(forward.x, 0, forward.z).normalized * spawnDistance;
            rulesMenu.transform.position =
                head.position + new Vector3(forward.x, 0, forward.z).normalized * spawnDistance;
        }

        if (showButton.action.WasPerformedThisFrame() && rulesMenu.activeSelf)
        {
            rulesMenu.SetActive(false);
        }
        
        var position = head.position;
        var forward1 = head.forward;
        menu.transform.LookAt(new Vector3(position.x,menu.transform.position.y,position.z));
        menu.transform.forward *= -1;
        rulesMenu.transform.LookAt(new Vector3(position.x,rulesMenu.transform.position.y,position.z));
        rulesMenu.transform.forward *= -1;
        menu.transform.position = position + 2 * forward1;
        rulesMenu.transform.position = position + 2 * forward1;
    }

    public void RulesButton()
    {
        rulesMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void BackButton()
    {
        rulesMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void PrincipalButton()
    {
        EnigmeManager.DictEnigme.Clear();
        SceneManager.LoadScene("MainMenu");
    }
}
