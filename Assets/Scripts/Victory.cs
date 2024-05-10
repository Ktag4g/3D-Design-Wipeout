using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject victoryScreen;

    public TextMeshProUGUI statsText;

    private Image collCheck1;
    private Image collCheck2;
    private Image collCheck3;

    public Sprite notCollectedSprite;
    public Sprite collectedSprite;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        collCheck1 = GameObject.Find("Coll 1").GetComponent<Image>();
        collCheck2 = GameObject.Find("Coll 2").GetComponent<Image>();
        collCheck3 = GameObject.Find("Coll 3").GetComponent<Image>();

        victoryScreen.SetActive(false);
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
                          "DeAths: " + gameManager.respawn.deathCount + "\n";

        gameManager.timer.timerOn = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CheckCollectibles()
    {
        //Checks if the first collectible was collected
        if (gameManager.coll1 == true)
        {
            collCheck1.sprite = collectedSprite;
        }
        else
        {
            collCheck1.sprite = notCollectedSprite;
        }

        //Checks if the second collectible was collected
        if (gameManager.coll2 == true)
        {
            collCheck2.sprite = collectedSprite;
        }
        else
        {
            collCheck2.sprite = notCollectedSprite;
        }

        //Checks if the third collectible was collected
        if (gameManager.coll3 == true)
        {
            collCheck3.sprite = collectedSprite;
        }
        else
        {
           collCheck3.sprite = notCollectedSprite;
        }
    }
}
