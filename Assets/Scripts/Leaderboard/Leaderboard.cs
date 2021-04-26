using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour
{
    private const string DOMAIN = "https://jimdinanttocore.ga";
    
    public void Start()
    {
        StartStart();
    }

    public void Update()
    {
        
    }

    public void StartStart()
    {
        StartCoroutine(GetLeaderboardData($"{DOMAIN}/leaderboard"));
    }

    private IEnumerator GetLeaderboardData(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                JSONNode leaderboardData = JSON.Parse(request.downloadHandler.text);
                int numberOfItems = leaderboardData["leaderboard"].Count;

                for (int i = 0; i < numberOfItems; i++)
                {
                    Debug.Log(leaderboardData["leaderboard"][i]["position"]);
                    Debug.Log(leaderboardData["leaderboard"][i]["name"]);
                    Debug.Log(leaderboardData["leaderboard"][i]["depth"]);
                }
            }
        }
    }
}
