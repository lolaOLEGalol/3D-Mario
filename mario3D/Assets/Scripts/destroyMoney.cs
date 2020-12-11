using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario")
        {
            Destroy(gameObject);
        }
    }
}
