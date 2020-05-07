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
            win = false;
            SceneManager.LoadScene(nameWinScene);
        }
        else if (lose)
        {
            lose = false;
            SceneManager.LoadScene(nameLoseScene);
        }
    }

}
