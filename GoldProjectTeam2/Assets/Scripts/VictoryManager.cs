using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private string nameScenePlay = "MainScene";
    [SerializeField] private string nameSceneMainMenu = "MainScene";

    public void RePlayButton()
    {
        SceneManager.LoadScene(nameScenePlay);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(nameSceneMainMenu);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
