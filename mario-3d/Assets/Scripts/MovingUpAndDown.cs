using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovingUpAndDown : MonoBehaviour
{
    float speed = 3;
    bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 20)
        {
            movingUp = false;
        }
        else if (transform.position.y <= 10)
        {
            movingUp = true;
        }

        if(movingUp)
        {
            transform.position = new Vector3(transform.position.y * speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.y * speed * Time.deltaTime, transform.position.z);
        }
        
    }
}
