using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private PlayerController player;

    public float bounceHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Finds character controller script
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Calls jump in character controller script
        player.Jump(bounceHeight);
    }
}
