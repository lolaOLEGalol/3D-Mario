using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creating1lvl : MonoBehaviour
{
    public GameObject myPrefab;

    void Start()
    {

        float StartX = 0.5f;
        float StartY = 0.5f;
        foreach (var o in myPrefab)
        for (int i = 0; i < 40; i++)
        {
            Instantiate(0, new Vector3(StartX + i, StartY + i, 0), Quaternion.identity);
        } 
    }
}
