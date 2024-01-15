using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MushroomPlusOne : MonoBehaviour
{
    private int mushroomValue;
    public TextMeshProUGUI mushroomText;
    private int currentHighScore;

    private void Update()
    {
        currentHighScore = PlayerPrefs.GetInt("Score", 0);
        mushroomText.text = "Score: " + mushroomValue.ToString();
        if (mushroomValue > currentHighScore)
        {
            PlayerPrefs.SetInt("Score", mushroomValue);
            PlayerPrefs.Save();
        }
    }
    
    public void AddOneToMushroom()
    {
        mushroomValue++;
    }
}
