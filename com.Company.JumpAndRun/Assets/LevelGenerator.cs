using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelGenerator : MonoBehaviour
{
    public GameObject startTile;
    public GameObject tile1;
    public GameObject tile2; 
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
    public GameObject tile13;

    private int tileAmount = 14;
    private float index = 0;
    private float tileSpacing = 13.75f;
    private float speed = -7f;
    private float speedChangeAmount= 1f;
    private float speedMin = -7f;
    private float speedMax = -25f;
    private float timeSinceLastSpeedChange = 0f;
    private float speedChangeInterval = 10f; // speed change all 30 seconds


    // Start is called before the first frame update
    void Start()
    {
        float startZ = 0.0f;
        int randomStart1 = Random.Range(0, tileAmount);
        int randomStart2 = Random.Range(0, tileAmount);
        int randomStart3 = Random.Range(0, tileAmount);

        // place first 3 empty tiles
        for (int i = 0; i < 3; i++)
        {
            GameObject start = Instantiate(startTile, transform);
            start.transform.position = new Vector3(0.85f, 0, startZ);
            startZ += tileSpacing;
        }

        // ------------------------- place first 3 random tiles -------------------------
        if (randomStart1 == 0)
        {
            GameObject tempStartTile1 = Instantiate(startTile, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 1)
        {
            GameObject tempStartTile1 = Instantiate(tile1, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 2)
        {
            GameObject tempStartTile1 = Instantiate(tile2, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 3)
        {
            GameObject tempStartTile1 = Instantiate(tile3, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 4)
        {
            GameObject tempStartTile1 = Instantiate(tile4, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 5)
        {
            GameObject tempStartTile1 = Instantiate(tile5, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 6)
        {
            GameObject tempStartTile1 = Instantiate(tile6, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 7)
        {
            GameObject tempStartTile1 = Instantiate(tile7, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 8)
        {
            GameObject tempStartTile1 = Instantiate(tile8, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 9)
        {
            GameObject tempStartTile1 = Instantiate(tile9, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 10)
        {
            GameObject tempStartTile1 = Instantiate(tile10, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 11)
        {
            GameObject tempStartTile1 = Instantiate(tile11, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 12)
        {
            GameObject tempStartTile1 = Instantiate(tile12, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }
        else if (randomStart1 == 13)
        {
            GameObject tempStartTile1 = Instantiate(tile13, transform);
            tempStartTile1.transform.position = new Vector3(0.85f, 0, tileSpacing * 3);
        }

        // ------------------------------------------------------------------------------

        if (randomStart2 == 0)
        {
            GameObject tempStartTile2 = Instantiate(startTile, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 1)
        {
            GameObject tempStartTile2 = Instantiate(tile1, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 2)
        {
            GameObject tempStartTile2 = Instantiate(tile2, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 3)
        {
            GameObject tempStartTile2 = Instantiate(tile3, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 4)
        {
            GameObject tempStartTile2 = Instantiate(tile4, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 5)
        {
            GameObject tempStartTile2 = Instantiate(tile5, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 6)
        {
            GameObject tempStartTile2 = Instantiate(tile6, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 7)
        {
            GameObject tempStartTile2 = Instantiate(tile7, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 8)
        {
            GameObject tempStartTile2 = Instantiate(tile8, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 9)
        {
            GameObject tempStartTile2 = Instantiate(tile9, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 10)
        {
            GameObject tempStartTile2 = Instantiate(tile10, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 11)
        {
            GameObject tempStartTile2 = Instantiate(tile11, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 12)
        {
            GameObject tempStartTile2 = Instantiate(tile12, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }
        else if (randomStart2 == 13)
        {
            GameObject tempStartTile2 = Instantiate(tile13, transform);
            tempStartTile2.transform.position = new Vector3(0.85f, 0, tileSpacing * 4);
        }

        // ------------------------------------------------------------------------------

        if (randomStart3 == 0)
        {
            GameObject tempStartTile3 = Instantiate(startTile, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 1)
        {
            GameObject tempStartTile3 = Instantiate(tile1, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 2)
        {
            GameObject tempStartTile3 = Instantiate(tile2, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 3)
        {
            GameObject tempStartTile3 = Instantiate(tile3, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 4)
        {
            GameObject tempStartTile3 = Instantiate(tile4, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 5)
        {
            GameObject tempStartTile3 = Instantiate(tile5, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 6)
        {
            GameObject tempStartTile3 = Instantiate(tile6, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 7)
        {
            GameObject tempStartTile3 = Instantiate(tile7, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 8)
        {
            GameObject tempStartTile3 = Instantiate(tile8, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 9)
        {
            GameObject tempStartTile3 = Instantiate(tile9, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 10)
        {
            GameObject tempStartTile3 = Instantiate(tile10, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 11)
        {
            GameObject tempStartTile3 = Instantiate(tile11, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 12)
        {
            GameObject tempStartTile3 = Instantiate(tile12, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
        else if (randomStart3 == 13)
        {
            GameObject tempStartTile3 = Instantiate(tile13, transform);
            tempStartTile3.transform.position = new Vector3(0.85f, 0, tileSpacing * 5);
        }
    }


    // Update is called once per frame
    void Update()
    {   
        // Track time since the last speed change
        timeSinceLastSpeedChange += Time.deltaTime;

        // Check, if 30 seconds over
        if (timeSinceLastSpeedChange >= speedChangeInterval)
        {
            // change speed
            speed = Mathf.Clamp(speed - speedChangeAmount, speedMax, speedMin);

            // Reset time since last speed change
            timeSinceLastSpeedChange = 0f;
        }


        gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        if (transform.position.z <= index)
        {
            int random = Random.Range(0, tileAmount);
            
            if (random == 0)
            {
                GameObject tempTile = Instantiate(startTile, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 1)
            {
                GameObject tempTile = Instantiate(tile1, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 2)
            {
                GameObject tempTile = Instantiate(tile2, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 3)
            {
                GameObject tempTile = Instantiate(tile3, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 4)
            {
                GameObject tempTile = Instantiate(tile4, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 5)
            {
                GameObject tempTile = Instantiate(tile5, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 6)
            {
                GameObject tempTile = Instantiate(tile6, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 7)
            {
                GameObject tempTile = Instantiate(tile7, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 8)
            {
                GameObject tempTile = Instantiate(tile8, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 9)
            {
                GameObject tempTile = Instantiate(tile9, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 10)
            {
                GameObject tempTile = Instantiate(tile10, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 11)
            {
                GameObject tempTile = Instantiate(tile11, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 12)
            {
                GameObject tempTile = Instantiate(tile12, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }
            else if (random == 13)
            {
                GameObject tempTile = Instantiate(tile13, transform);
                tempTile.transform.position = new Vector3(0.85f, 0, tileSpacing * 6);
            }

            index = index - tileSpacing;
        }
    }
}