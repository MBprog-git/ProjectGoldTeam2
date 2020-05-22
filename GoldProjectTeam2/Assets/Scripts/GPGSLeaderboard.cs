﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLeaderboard : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
        //Social.Active.ShowLeaderboardUI();
    }

    public void UpdateLeaderboard()
    {
        if (PlayerPrefs.GetInt("TimeToUpdate", 0) == 0)
        {
            return;
        }
        Social.ReportScore(PlayerPrefs.GetInt("TimeToUpdate", 0), GPGSIds.leaderboard_best_time, (bool success) =>
       {
           if (success)
           {
               PlayerPrefs.SetInt("TimeToUpdate", 0);       
           }
           else
           {
               Debug.Log("leaderboard fail");
           }
       });
    }
}
