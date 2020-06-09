using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nameScenePlay = "MainScene";

    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelHowToPlay;
    [SerializeField] private GameObject Credits;

    public Animator animationMainMenu;

    AsyncOperation op;

    private void Start()
    {
        op = SceneManager.LoadSceneAsync(nameScenePlay);
        op.allowSceneActivation = false;
        animationMainMenu.SetBool("PlayAnimation", true);
    }

    public void PlayButton()
    {
        op.allowSceneActivation = true;
    }

    public void StartButton()
    {
        panelMenu.SetActive(false);
        panelHowToPlay.SetActive(true);
    }

    public void OptionButton()
    {
        panelOptions.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void LeaderBoardButton()
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
    
    public void OpenCredits()
    {
        Credits.SetActive(true);
    }
      public void CloseCredits()
    {
        Credits.SetActive(false);
    }

    public void OpenLink(string Lien)
    {
        if (Lien != null)
        {
            Application.OpenURL(Lien);

        }
    }

}
