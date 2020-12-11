using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerStay(Collider other)
    {
        isGround = other != null;
    }

    private void OnTriggerExit(Collider other)
    {
        isGround = false;
    }
}
