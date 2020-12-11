using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enimiesRL : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private bool visibleMario = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "invert")
        {
            speed *= -1;
        }

        if (other.tag == "Sphere")
        {
            visibleMario = true;
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        
    }
    void Update()
    {
        if (visibleMario)
        {
            Vector3 move = new Vector3(1, 0, 0);
            transform.Translate(move * Time.deltaTime * speed);
        }
        
    }
}
