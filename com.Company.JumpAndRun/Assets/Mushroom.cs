using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mushroom : MonoBehaviour
{
    private MushroomPlusOne MushroomText;
    private bool isCounted = false;

    void Start()
    {
        MushroomText = FindObjectOfType<MushroomPlusOne>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (!isCounted)
        {
            MushroomText.AddOneToMushroom();
            isCounted = true;
            Destroy(gameObject);
        }
    }
}
