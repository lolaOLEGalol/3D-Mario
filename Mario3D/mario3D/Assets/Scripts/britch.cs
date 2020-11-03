using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class britch : MonoBehaviour
{

    private void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "mario" && other.GetComponent<player>().lvl_mario > 1)
        {
            Destroy(gameObject);
        }
    }
}
