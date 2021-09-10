using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
public class BringerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D ri;
    public float speed;
    public Animator anima;
    public float facedirction;
    public bool xunluo = true;

    public LayerMask player;

    public GameObject leftpoint;
    public GameObject rightpoint;

    private float left;
    private float right;

    public bool CanKill = false;
    public bool moveable = true;

    public float timer;
    public bool timerBegin;
    public float Htimer;
    public bool HtimerBegin;

    public AudioSource WalkAS;
    public AudioSource HitAS;
    public AudioSource DeadAS;

    public GameObject Congratulations;





    void Start()
    {
        facedirction = -1;
        left = leftpoint.transform.position.x;
        right = rightpoint.transform.position.x;
        Congratulations.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        

        if (moveable)
            Move();
        // if(Input.GetKey(KeyCode.O))
        //anima.Play("Attack");
        // if (Input.GetKey(KeyCode.I))
        //anima.Play("Walk");

        DestroyThis();
        HUrtThis();



    }
    public void MoveL()
    {
        transform.localScale = new Vector3(1, 1, 1);

        ri.velocity = new Vector2(-1 * speed, 0);

        anima.SetBool("Walk", true);
       // WalkAS.Play();


    }
    public void MoveR()
    {
        transform.localScale = new Vector3(-1, 1, 1);

        ri.velocity = new Vector2(speed, 0);

        anima.SetBool("Walk", true);


    }

    public void Move()
    {
        //Debug.Log(Mathf.Abs(ri.velocity.x));
        if (facedirction < 0)
        {
            MoveL();
        }
        if (facedirction > 0)
        {
            MoveR();
        }

        if (xunluo)
        {
            if (transform.position.x < left)
            {
                facedirction = 1;
            }
            if (transform.position.x > right)
            {
                facedirction = -1;
            }
        }

        // if ( Mathf.Abs(ri.velocity.x) < 0.1)
        // {
        // //    anima.SetBool("Walk", false);
        // }
    }

    void OnTriggerStay2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            facedirction = other.transform.position.x - this.transform.position.x;
            xunluo = false;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        xunluo = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        // Debug.Log("开始被子弹打了");

       
        if (collision.transform.tag == "Bullet" && CanKill && !anima.GetBool("Attack") && !anima.GetBool("Attack2"))
        {
           
            Death();

        }
        if (collision.transform.tag == "Bullet" && !CanKill && !anima.GetBool("Attack")&& !anima.GetBool("Attack2"))
        {
                    
            Hurt();

        }
        if (collision.transform.tag == "Bullet" )
        {
            Debug.Log("子弹打Destory");
            Destroy(collision.gameObject);

        }
       
    }

    public void Death(){
        moveable = false;

        anima.SetBool("Dead", true);

        DeadAS.Play();

        timerBegin = true;


    }

    void DestroyThis()
    {
        if (timer > 0.8) // 计时器延迟0.8秒播完动画
        {
            Destroy(gameObject);
            Congratulations.SetActive(true);
            
        }
        if (timerBegin)   //计时器开始
            timer += Time.deltaTime;
    }

    public void Hurt()
    {
        moveable = false;

        anima.SetBool("Hurt", true);

        HtimerBegin = true;

        HitAS.Play();

    }

    void HUrtThis()
    {
        if (Htimer > 0.4) // 计时器延迟0.4秒播完动画
        {
            anima.SetBool("Hurt",false);
            Htimer = 0;
            HtimerBegin = false;
            moveable = true;

        }
        if (HtimerBegin)   //计时器开始
            Htimer += Time.deltaTime;
    }




}
