using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSAuthentification : MonoBehaviour
{
    //public static PlayGamesPlatform platform;

    // Start is called before the first frame update
    void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            // handle results
        });

        //Social.Active.localUser.Authenticate(success =>
        //{
        //    if (success)
        //    {
        //        Debug.Log("log in success");
        //    }
        //    else
        //    {
        //        Debug.Log("fail to log");
        //    }
        //});
    }

    //public void StartConnection()
    //{
    //    if (platform == null)
    //    {
    //        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
    //        PlayGamesPlatform.InitializeInstance(config);
    //        PlayGamesPlatform.DebugLogEnabled = true;

    //        platform = PlayGamesPlatform.Activate();
    //    }

    //    Social.Active.localUser.Authenticate(success =>
    //    {
    //        if (success)
    //        {
    //            Debug.Log("log in success");
    //        }
    //        else
    //        {
    //            Debug.Log("fail to log");
    //        }
    //    });
    //}
}
