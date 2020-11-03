using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float speed = 0.23f;
    private int lvl_mario = 1;
    public GameObject stone;
    public GameObject question;


    private void OnCollisionEnter(Collision other)
    {
        print("HAy");
    }

    void TranslateMario()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        TranslateMario();
    }
}
