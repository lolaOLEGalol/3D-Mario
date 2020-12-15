using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject mario;
    void Update()
    {
        transform.position = new Vector3(mario.transform.position.x - 3, mario.transform.position.y-25, mario.transform.position.z);
    }
}
