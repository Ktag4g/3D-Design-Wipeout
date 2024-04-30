using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
    private PlayerController player;

    public Vector3 force;
    public bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        //Finds character controller script
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (launched)
        {
            player.controller.Move(force * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        launched = true;
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(1);
        launched = false;
    }
}
