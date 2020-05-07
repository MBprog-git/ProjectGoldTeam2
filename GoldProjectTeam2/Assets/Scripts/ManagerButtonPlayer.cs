using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtonPlayer : MonoBehaviour
{
    [HideInInspector] public bool goLeft = false;
    [HideInInspector] public bool goRight = false;

    [SerializeField] private GameObject panelPlay;
    [SerializeField] private GameObject panelPause;

    [SerializeField] private string nameSceneMainMenu = "MainMenu";

    public void ButtonDownLeft()
    {
        goLeft = true;
    }

    public void ButtonUpLeft()
    {
        goLeft = false;
    }

    public void ButtonDownRight()
    {
        goRight = true;
    }

    public void ButtonUpRight()
    {
        goRight = false;
    }

    public void ButtonPause()
    {
        panelPlay.SetActive(false);
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ButtonReturnPause()
    {
        panelPlay.SetActive(true);
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void ButtonMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameSceneMainMenu);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
