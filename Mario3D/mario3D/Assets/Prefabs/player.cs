using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float speed = 0.23f;
    public int lvl_mario = 1;
    private float jump = 5f;
    public GameObject stone;
    public GameObject question;


    private void OnTriggerStay (Collider other)
    {

        if (other.tag == "down" && Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jump);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boost" && lvl_mario < 3)
        {
            lvl_mario++;
        }

        if (other.tag == "enemy" && lvl_mario > 0)
        {
            lvl_mario--;
        }

        if (other.tag == "hole")
        {
            lvl_mario = 0;
        }
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
        if (lvl_mario == 0)
        {
            Destroy(gameObject);
        }
    }
}
