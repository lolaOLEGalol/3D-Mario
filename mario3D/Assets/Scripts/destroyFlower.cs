using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFlower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mario")
        {
            Destroy(gameObject);
        }
    }
}
