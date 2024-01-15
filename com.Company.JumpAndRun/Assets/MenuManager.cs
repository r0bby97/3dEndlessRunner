using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI currentDailySteps;

    String currentUserRequest = "https://v1.nocodeapi.com/brachialis97/fit/biSUuUxDnYBEWZTz/aggregatesDatasets?dataTypeName=steps_count&customTimePeriod="; // individueller Nutzer
    String currentDay = "";
    String jsonURL = "";
    int currentSteps = 0;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentPlaytimeText;
    private int currentHighScore;
    private float rawPlaytimeInSeconds;
    private float secondsFor1steps = 0.18f; //((30Minuten * 60Sekunden) / 10000Schritte)


    // Start is called before the first frame update
    public void Start()
    {
        GetCurrentDay();
        GetJSON();
        PlaytimeCalculation();

        // Add HighScore to MainMenu
        currentHighScore = PlayerPrefs.GetInt("Score", 0);
        highScoreText.text = "High Score: " + currentHighScore.ToString();
    }

    public void OnButtonClickPlayWhileWalking()
    {
        SceneManager.LoadScene("Scenes/game");
        PlayerPrefs.SetString("CurrentGamemode", "playWhileWalking");
        PlayerPrefs.Save();
    }

    public void OnButtonClickPlayWithTime()
    {
        SceneManager.LoadScene("Scenes/game");
        PlayerPrefs.SetString("CurrentGamemode", "playWithTime");
        PlayerPrefs.Save();
    }

    public void GetCurrentDay()
    {
        if (GetComponent<TextMeshProUGUI>() != null)
        {
            currentDailySteps.text = GetComponent<TextMeshProUGUI>().text;
        }
        else
        {
            currentDailySteps.text = "0";
        }

        CultureInfo english = new CultureInfo("en-EN");
        String firstPart = ("[\"");
        String secondPart = System.DateTime.Now.ToLocalTime().ToString("ddd", english);
        String thirdPart = (",+");
        String fourthPart = System.DateTime.Now.ToLocalTime().ToString("dd'+'MMM'+'yyyy", english); ;
        String fifthPart = ("+00:00:00+GMT%2B2\",\"");
        String sixthPart = ("+23:59:59+GMT%2B2");
        String seventhPart = ("\"]");

        currentDay = (firstPart + secondPart + thirdPart + fourthPart +
        fifthPart + secondPart + thirdPart + fourthPart + sixthPart + seventhPart).ToString();
        Debug.Log("Current Day: " + currentDay);
    }

    public void GetJSON()
    {
        jsonURL = currentUserRequest + currentDay;
        Debug.Log("jsonURL: " + jsonURL);

        using (WebClient client = new WebClient())
        {
            string jsonResponse = client.DownloadString(jsonURL);

            // JSON-Text in ein JObject umwandeln
            JObject jsonObject = JObject.Parse(jsonResponse);

            currentSteps = (int)jsonObject["steps_count"][0]["value"];
            currentDailySteps.text = currentSteps.ToString();

            // CurrentSteps transport to Game Scene
            PlayerPrefs.SetInt("CurrentSteps", currentSteps);
            PlayerPrefs.Save();
        }
    }

    public void PlaytimeCalculation()
    {
        int steps = PlayerPrefs.GetInt("CurrentSteps", 0);

        // Check new day
        string lastPlayedDate = PlayerPrefs.GetString("LastPlayedDate", "");
        string currentDate = System.DateTime.Now.ToString("dd'+'MMM'+'yyyy");

        if (!lastPlayedDate.Equals(currentDate))
        {
            // new day, reset time and playedTime
            rawPlaytimeInSeconds = (float)(secondsFor1steps * steps);
            PlayerPrefs.SetString("LastPlayedDate", currentDate);
            PlayerPrefs.SetFloat("PlayedTimeInSeconds", 0f);
        }
        else
        {
            // same day, subtract time
            float playedTime = PlayerPrefs.GetFloat("PlayedTimeInSeconds", 0);
            Debug.Log("playedTime: " + playedTime); 
            rawPlaytimeInSeconds = Mathf.Max(0, (secondsFor1steps * steps) - playedTime);

        }

        int minutes = Mathf.FloorToInt(rawPlaytimeInSeconds / 60);
        int seconds = Mathf.FloorToInt(rawPlaytimeInSeconds % 60);

        currentPlaytimeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + " [mm:ss]";

        // Playtime transport to Game Scene
        PlayerPrefs.SetFloat("RawPlaytimeInSeconds", rawPlaytimeInSeconds);
        PlayerPrefs.Save();
    }
}
