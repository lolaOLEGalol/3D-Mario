using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enimiesUD : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    private bool check = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "invert")
        {
            speed *= -1;
        }

        if (other.tag == "Sphere")
        {
            check = true;
        }
    }
    void Update()
    {
        if (check)
        {
            Vector3 move = new Vector3(0, 1, 0);
            transform.Translate(move * speed * Time.deltaTime);
        }
        
    }
}
