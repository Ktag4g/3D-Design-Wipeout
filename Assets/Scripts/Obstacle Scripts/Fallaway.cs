using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallaway : MonoBehaviour
{
    public float timeTillFall;

    private bool falling = false;

    // Update is called once per frame
    void Update()
    {
        if(falling == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 3);
        }

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeTillFall);
        falling = true;
    }


}
