using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlaytimeManager : MonoBehaviour
{
    public TextMeshProUGUI currentPlaytimeText;
    private float rawPlaytimeInSeconds;
    private float playedTimeInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        rawPlaytimeInSeconds = (float)PlayerPrefs.GetFloat("RawPlaytimeInSeconds", 0);
        playedTimeInSeconds = PlayerPrefs.GetFloat("PlayedTimeInSeconds", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Timer activated in Gamemode playWithTime
        if (PlayerPrefs.GetString("CurrentGamemode", "no value") == "playWithTime")
        {
            timer();
        }
        // Hide Timer if Gamemode is playWhileWalking
        if (PlayerPrefs.GetString("CurrentGamemode", "no value") == "playWhileWalking")
        {
            currentPlaytimeText.gameObject.SetActive(false);
        }
    }

    void timer()
    {
        if (rawPlaytimeInSeconds > 0)
        {
            rawPlaytimeInSeconds -= Time.deltaTime;

            // Update played time during gameplay
            playedTimeInSeconds += Time.deltaTime;

            // Save played time only if it has changed to reduce costs
            if (playedTimeInSeconds != PlayerPrefs.GetFloat("PlayedTimeInSeconds", 0))
            {
                PlayerPrefs.SetFloat("PlayedTimeInSeconds", playedTimeInSeconds);
                PlayerPrefs.Save();
            }

            UpdatePlaytimeText();
        }
        if (rawPlaytimeInSeconds <= 0)
        {
            SceneManager.LoadScene("menu");
        }
    }

    void UpdatePlaytimeText()
    {
        int minutes = Mathf.FloorToInt(rawPlaytimeInSeconds / 60);
        int seconds = Mathf.FloorToInt(rawPlaytimeInSeconds % 60);

        currentPlaytimeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + " [mm:ss]";
    }
}