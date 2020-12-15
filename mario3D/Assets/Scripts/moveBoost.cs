using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoost : MonoBehaviour
{
    private float speed = -5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
