using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public GameObject mario;
    public Transform spawnMario;

    void Start()
    {
        Instantiate(mario, spawnMario.position, spawnMario.rotation);
    }
}
