using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 0.23f;
    public int lvl_mario = 1;
    public float jump = 5f;
    public Transform spawnPoint;
    public Transform Respawn;
    [SerializeField] private int _realHPMario = 3;
    bool FaceRight = true;  
    Rigidbody RB; 
    [SerializeField]private int money;
    //bool down = false;


    public Text txtMoney; // UI 
    public Text txtHp;

    public AudioClip a_money;
    public AudioClip a_jump;
    public AudioClip a_death;
    public AudioClip a_boost;
    public AudioClip a_winDragon;

    private AudioSource myAudio;

    private float SpawnTime = 3.1f;
    private float TimeToSpawn;

    Animator anim;



    private bool CheckGround()
    {
        return transform.Find("GroundCheck").GetComponent<checkGround>().isGround;
    }

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        money = 0;
        RB = GetComponent<Rigidbody>();
        anim = transform.Find("MarioBoxers").GetComponent<Animator>();
        
    }

    //private void OnTriggerStay (Collider other)
    //{
        
    //    if ((other.tag == "down" || other.tag == "question") && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        RB.AddForce(new Vector2(0f, jump), ForceMode.Impulse);
    //        down = true;
    //    }
    //}

    

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "down")
    //    {
    //        down = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boost" && lvl_mario < 3)
        {
            lvl_mario++;
            myAudio.PlayOneShot(a_boost);
        }

        if (other.tag == "money")
        {
            money++;
            myAudio.PlayOneShot(a_money);
        }

        if (other.tag == "enemy" && lvl_mario > 0)
        {
            lvl_mario--;
        }

        if (other.tag == "hole")
        {
            lvl_mario = 0;
        }

        if (lvl_mario == 0)
        {
            Death();
            myAudio.PlayOneShot(a_death);
        }

        if (lvl_mario == 1)
        {
            Scale(1f);
        }
        else if (lvl_mario == 2)
        {
            Scale(1.5f);
        }
        else if (lvl_mario >= 3)
        {
            Scale(2f);
        }

        //

        if (other.tag == "Respawn")
        {
            spawnPoint = Respawn;
        }
    }

    void Scale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    //void TranslateMario()
    //{
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.Translate(Vector3.left * speed);
            
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.Translate(Vector3.right * speed);
    //    }
    //    else if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.Translate(Vector3.back * speed);
    //    }
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.Translate(Vector3.forward * speed);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        if (FaceRight)
    //        {
    //            transform.Rotate(0, 180, 0);
    //            FaceRight = false;
    //        }
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        if (FaceRight)
    //        {
    //            transform.Rotate(0, 180, 0);
    //            FaceRight = false;
    //        }
    //    }
    //}

    //void Flip()
    //{
    //    if (!Face)
    //    {
    //        Vector3 Tern = transform.localRotation;
    //        Tern.x *= -1;
    //        transform.localScale = Tern;
    //    }

    //}

    void TranslateNewMario()
    {
        //float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 translateDir = new Vector3(-horizontal, 0, 0);

        transform.Translate(translateDir * speed * Time.deltaTime);
        print(horizontal);

        //if (horizontal > 0)
        //{
        //    transform.localRotation = new Quaternion(0, 0, 0, 0);
        //}
        //else if (horizontal < 0)
        //{
        //    transform.localRotation = new Quaternion(0, 180, 0, 0);
        //}
        if (Input.GetKey(KeyCode.D))
        {
            if (!FaceRight)
            {
                transform.GetChild(0).Rotate(0, -180, 0);
                FaceRight = true;
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (FaceRight)
            {
                transform.GetChild(0).Rotate(0, 180, 0);
                FaceRight = false;
            }
        }
    }

    void Death()
    {
        //anim.SetBool("is_death", true);
        // Destroy(gameObject);
        _realHPMario--;
        lvl_mario = 1;

        

        if (_realHPMario <= 0)
        {
            SceneManager.LoadScene(0);
            _realHPMario = 3;
        }
        else
        {
            transform.position = spawnPoint.position;
        }
        RB.velocity = Vector3.zero;


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //transform.position = spawnPoint.position;

        //Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
    }

    void Update()
    {
        //TranslateMario(); 
        TranslateNewMario();
        Animations();
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround()) //down && 
        {
            RB.AddForce(Vector3.up * jump, ForceMode.Impulse);
            myAudio.PlayOneShot(a_jump);
        }
        /*if(anim.GetBool("is_death"))
        {
            if (TimeToSpawn <= 0)
            {
                TimeToSpawn = SpawnTime;
                anim.SetBool("is_death", false);
            }
            else
            {
                TimeToSpawn -= Time.deltaTime;
            }
        }*/

        txtMoney.text = "Money: " + money;
        txtHp.text = "HP: " + _realHPMario;
        
    }


    // анимации

    void Animations()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("is_running", true);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("is_running", false);
        }

        /* if (Input.GetKey(KeyCode.Space))
         {
             anim.SetBool("is_jumping", true);
         }

         if (CheckGround())
         {
             anim.SetBool("is_landed", true);
             anim.SetBool("is_jumping", false);
         }

         if (!CheckGround())
         {
             anim.SetBool("is_landed", false);
         }*/

    }

    void Wait()
    {
        var watch = new Stopwatch();
        watch.Start();
        using (var task = Task.Delay(3100))
        {
            task.Wait();
        }
        watch.Stop();
    }
}
