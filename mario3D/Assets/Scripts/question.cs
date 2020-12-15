using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class question : MonoBehaviour
{
    public GameObject boost;
    private bool check = true;
    private Vector3 pos;
    [SerializeField] private bool GribAndMoney = true;

    private void Awake()
    {
        if(GribAndMoney)
        {
            pos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z + 3.5f);
        }
        else
        {
            pos = new Vector3(transform.position.x + 1.3f, transform.position.y + 4, transform.position.z + 4.5f);
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario" && check)
        {
            Instantiate(boost, pos, boost.transform.rotation);
            check = false;
        }
    }
}
