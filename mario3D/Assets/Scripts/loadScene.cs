using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int nextScene;
    public void LoadScene()// Start
    {
        SceneManager.LoadScene(nextScene);
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mario")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
