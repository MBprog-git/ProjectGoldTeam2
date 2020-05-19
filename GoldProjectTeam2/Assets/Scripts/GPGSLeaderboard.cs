using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLeaderboard : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboard()
    {
        if (PlayerPrefs.GetFloat("ScoreToUpdate", 0) == 0)
        {
            return;
        }
        Social.ReportScore(PlayerPrefs.GetInt("ScoreToUpdate", 1), GPGSIds.leaderboard_best_time, (bool success) =>
       {
           if (success)
           {
               PlayerPrefs.SetFloat("ScoreToUpdate", 0);
           }
       });
    }
}
