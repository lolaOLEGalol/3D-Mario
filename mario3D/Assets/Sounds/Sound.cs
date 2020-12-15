using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip money;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip finish;
    public AudioClip boost;
    public AudioClip winDragon;

    private AudioSource myAudio;

    public GameObject mario;
    private int lvl_mario;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        lvl_mario = mario.GetComponent<player>().lvl_mario;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boost" /*&& lvl_mario < 3*/)
        {
            myAudio.PlayOneShot(boost);
        }

        if (other.tag == "money")
        {
            myAudio.PlayOneShot(money);
        }

        /*if (other.tag == "enemy" && lvl_mario > 0)
        {
            myAudio.PlayOneShot();
        }*/

       


        /*if (other.tag == "Respawn")
        {
            myAudio.PlayOneShot(); //finish??
        }*/
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAudio.PlayOneShot(jump);
        } 

        if (lvl_mario == 0)
        {
            myAudio.PlayOneShot(death);
        }
    }
}
