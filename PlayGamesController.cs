using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
public class PlayGamesController : MonoBehaviour
{
    private static bool isAuthenticated = false;
    
    void Start()
    {
        DontDestroyOnLoad(this);
 }
public static void AddScoreToLeaderBoard(string leaderBoard, int score)
 {
     if (Social.localUser.authenticated)
     {
         Social.ReportScore(score, ".........", success => { });
     }
 }
public void ShowLeaderBoard()
 {
       try
        {
             PlayGamesClientConfiguration config = new      PlayGamesClientConfiguration.Builder().Build();
             PlayGamesPlatform.InitializeInstance(config);
             PlayGamesPlatform.DebugLogEnabled = true;
             PlayGamesPlatform.Activate();
             Social.localUser.Authenticate((bool success) =>{ });
              if (Social.localUser.authenticated)
     {
          Social.ShowLeaderboardUI();
     }
        }
        catch (Exception ex)
        {
              Debug.Log("Unable to setup google play account " + ex.InnerException);
        }
     
 }
}