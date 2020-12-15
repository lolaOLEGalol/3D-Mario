using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int nextScene;
    public AudioClip a_finish;
    public GameObject source;
    private bool check = true;

    private AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario" && check)
        {
            check = false;
            source.SetActive(false);
            myAudio.PlayOneShot(a_finish);
            Invoke(nameof(LoadScene), 5.3f);
        }
    }
}
