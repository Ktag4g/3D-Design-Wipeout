using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private GameManager gameManager;

    public int collInt = 0;

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
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            if(collInt == 1)
            {
                gameManager.coll1 = true;
            }
            else if (collInt == 2)
            {
                gameManager.coll2 = true;
            }
            else if (collInt == 3)
            {
                gameManager.coll3 = true;
            }
            else
            {
                Debug.Log("Invalid Count");
            }

        }
    }
}
