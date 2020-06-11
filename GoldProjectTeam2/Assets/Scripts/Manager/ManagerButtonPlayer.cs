using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerButtonPlayer : MonoBehaviour
{
    [HideInInspector] public bool goLeft = false;
    [HideInInspector] public bool goRight = false;

    [SerializeField] private GameObject panelPlay;
    [SerializeField] private GameObject panelPause;

    [SerializeField] private string nameSceneMainMenu = "MainMenu";

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }  
    
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
        GameManager.instance.Journal.GetComponent<JournalMB>().CallOut();
        Time.timeScale = 1;
    }

    public void ButtonMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameSceneMainMenu);
    }

    public void ButtonGoJournal()
    {
        panelPlay.SetActive(false);
        panelPause.SetActive(false);
        GameManager.instance.Journal.GetComponent<JournalMB>().CallIn();
    }

    public void ButtonExit()
    {
        Application.Quit();
    }    
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
