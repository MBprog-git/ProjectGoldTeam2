using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{

    [SerializeField]
    private bool win = false;
    [SerializeField]
    private bool lose = false;

    [SerializeField] private string nameWinScene = "VictoryScene";
    [SerializeField] private string nameLoseScene = "LoseScene";

    private void Update()
    {
        if (win)
        {
            GameManager.instance.Player.GetComponent<Score>().StopTimer();
            GameManager.instance.Player.GetComponent<GPGSLeaderboard>().UpdateLeaderboard();
            win = false;
            SceneManager.LoadScene(nameWinScene);
        }
        else if (lose)
        {
            SceneManager.LoadScene(nameLoseScene);
            lose = false;
        }
    }

}
