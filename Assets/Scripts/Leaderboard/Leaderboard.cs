using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour
{
    private const string DOMAIN = "https://jimdinanttocore.ga";

    public GameObject LeaderboardRow;
    public Transform parentPanel;
    
    public void Start()
    {
        StartStart();
    }

    public void Update()
    {
        
    }

    public void StartStart()
    {
        //TODO: If PlayerPrefs is implemented uncomment line below
        // string uuid = PlayerPrefs.GetString("uuid");
        string uuid = "6eaa09b2-b7d6-491e-9bd1-b34a028722fd";
        
        StartCoroutine(GetLeaderboardData($"{DOMAIN}/leaderboard"));
        StartCoroutine(GetUserLeaderboardPosition($"{DOMAIN}/leaderboard/{uuid}"));
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
                LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(request.downloadHandler.text);
                
                foreach (LeaderboardItem leaderboardItem in data.leaderboard)
                {
                    GameObject row = Instantiate(LeaderboardRow);
                    row.transform.SetParent(parentPanel);

                    foreach (Transform child in row.transform)
                    {
                        if (child.name == "Position")
                            child.GetComponent<TextMeshProUGUI>().text = leaderboardItem.position.ToString();
                        if (child.name == "Name")
                            child.GetComponent<TextMeshProUGUI>().text = leaderboardItem.name;
                        if (child.name == "Depth")
                            child.GetComponent<TextMeshProUGUI>().text = leaderboardItem.depth.ToString();
                    }
                }
            }
        }
    }

    private IEnumerator GetUserLeaderboardPosition(string uri)
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
                //playersLeaderboardItem = JsonUtility.FromJson<LeaderboardItem>(request.downloadHandler.text);
            }
        }
    }
}
