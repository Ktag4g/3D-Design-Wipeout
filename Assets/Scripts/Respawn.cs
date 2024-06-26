using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Respawn : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 currentCheckpoint;
    public int deathCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = gameObject.transform.position;
        Debug.Log(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Debug.Log("Game Over");
            controller.enabled = false;
            gameObject.transform.position = currentCheckpoint;
            deathCount++;
            controller.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPoint")
        {
            UpdateCheckpoint();
        }
    }

    private void UpdateCheckpoint()
    {
        currentCheckpoint = gameObject.transform.position;
        Debug.Log("Checkpoint Reached!");
    }
}
