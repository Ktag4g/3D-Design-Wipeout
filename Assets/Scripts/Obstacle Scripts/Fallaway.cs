using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallaway : MonoBehaviour
{
    public float timeTillFall;
    public float fallSpeed;
    public Vector3 direction;

    private bool falling = false;

    // Update is called once per frame
    void Update()
    {
        if (falling == true)
        {
            transform.Translate(direction * Time.deltaTime * fallSpeed);
        }

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Fall());
        Debug.Log("Touched");
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeTillFall);
        falling = true;
        Debug.Log("Falling");
    }
}
