using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Respawn respawn;
    public timer timer;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.Find("Player").GetComponent<Respawn>();
        timer = GameObject.Find("timer").GetComponent<timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
