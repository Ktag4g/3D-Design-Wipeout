using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject victoryScreen;

    public TextMeshProUGUI statsText;

    private char collCheck1 = 'O';
    private char collCheck2 = 'O';
    private char collCheck3 = 'O';

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(victoryScreen.activeInHierarchy == true)
        {
            if(Input.GetMouseButton(0))
            {
                gameManager.ResetGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            VictoryScreen();
        }
    }

    private void VictoryScreen()
    {
        victoryScreen.SetActive(true);
        CheckCollectibles();

        statsText.text =  gameManager.timer.timeText.text + "\n" +
                          "DeAths: " + gameManager.respawn.deathCount + "\n" +
                          "Stars: " + collCheck1 + " " + collCheck2 + " " + collCheck3;

        gameManager.timer.timerOn = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CheckCollectibles()
    {
        //Checks if the first collectible was collected
        if (gameManager.coll1 == true)
        {
            collCheck1 = '!';
        }
        else
        {
            collCheck1 = 'O';
        }

        //Checks if the second collectible was collected
        if (gameManager.coll2 == true)
        {
            collCheck2 = '!';
        }
        else
        {
            collCheck2 = 'O';
        }

        //Checks if the third collectible was collected
        if (gameManager.coll3 == true)
        {
            collCheck3 = '!';
        }
        else
        {
            collCheck3 = 'O';
        }
    }
}
