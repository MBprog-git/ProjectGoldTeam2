using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nameScenePlay = "MainScene";

    [SerializeField] private GameObject panelControl;
    [SerializeField] private GameObject panelMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene(nameScenePlay);
    }

    public void ControlButton()
    {
        panelControl.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void ReturnButton()
    {
        panelControl.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
