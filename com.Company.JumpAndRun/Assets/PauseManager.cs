using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private float accelerationZ; // Acceleration along the Z-axis
    private int schrittZaehler; // Step counter
    private int tmpSchrittZaehler = -1; // Should be different for the first time compared to schrittZaehler
    public float threshold = 1.25f; // Threshold for acceleration

    public GameObject pausePanel; // Reference to your overlay window or panel
    public TextMeshProUGUI noStepsDetectedText;


    // Start is called before the first frame update
    void Start()
    {
        schrittZaehler = 0;

        // Stepdetection activated in Gamemode playWhileWalking
        if (PlayerPrefs.GetString("CurrentGamemode", "no value") == "playWhileWalking")
        {
            StartCoroutine(checkDoingSteps());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Capture acceleration along the Z-axis
        accelerationZ = Input.acceleration.z;

        // Check if a step is detected
        if (accelerationZ > threshold || accelerationZ < -threshold)
        {
            schrittZaehler++;
            Debug.Log("Step detected! Step counter: " + schrittZaehler);
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName == "Scenes/menu") // otherwise game is frozen when game --> pause --> main menu --> game
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(sceneName);
    }

    // Coroutine to continuously check for steps
    IEnumerator checkDoingSteps()
    {
        while (true)
        {
            if (tmpSchrittZaehler != schrittZaehler)
            {
                tmpSchrittZaehler = schrittZaehler;
            }
            else
            {
                PauseGame();
                noStepsDetectedText.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(5f);
        }
    }

    // Function to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0; // Pause the game time
        pausePanel.SetActive(true); // Activate the overlay window or panel
        
    }
    
    // Function to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume normal game time
        pausePanel.SetActive(false); // Deactivate the overlay window or panel
    }
}