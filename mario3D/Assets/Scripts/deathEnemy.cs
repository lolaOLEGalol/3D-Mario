using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario")
        {
            Destroy(gameObject);
        }
    }
}
