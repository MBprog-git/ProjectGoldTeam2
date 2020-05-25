using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nameScenePlay = "MainScene";

    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelMenu;

    AsyncOperation op;

    private void Start()
    {
        op = SceneManager.LoadSceneAsync(nameScenePlay);
        op.allowSceneActivation = false;
    }

    public void PlayButton()
    {
        op.allowSceneActivation = true;
    }

    public void OptionButton()
    {
        panelOptions.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void AchievementButton()
    {
        panelMenu.SetActive(false);
    }

    public void ReturnButton()
    {
        panelOptions.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

}
