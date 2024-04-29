using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject victoryScreen;

    public TextMeshProUGUI statsText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            VictoryScreen();
        }
    }

    private void VictoryScreen()
    {
        victoryScreen.SetActive(true);

        statsText.text =  gameManager.timer.timeText.text + "\n" +
                          "DeAths: " + gameManager.respawn.deathCount + "\n" +
                          "Stars: O O O";
    }
}
