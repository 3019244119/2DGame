using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerAttack2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anima;
    public GameObject point;
    public GameObject yun;
    public GameObject weizhi;

    public BringerAttack bringerA;

    public Rigidbody2D ri;
    public GameObject playerfu;
   

    public bool zhunbei = true;
    public bool counts = false;
    public bool inrange = false;
    public bool CreatTimerBegin = false;
    public bool keyifang = true;

    public float timer;
    public float yanchi;
    public float lengque;
    public float CreatTimer;

    public GameObject leftpoint;
    public GameObject rightpoint;

    private float left;
    private float right;

    public AudioSource AttackAS;

    void Start()
    {
       // playerTrans = ri.GetComponentInParent<Transform>();
        
        left = leftpoint.transform.position.x;
        right = rightpoint.transform.position.x;
        playerfu = ri.transform.parent.gameObject;
       // Debug.Log(left);
       // Debug.Log(right);

    }

    // Update is called once per frame
    void Update()
    {
        AttackToWalk();
        CD();
        DoAttack();
        CreatY();

        //Debug.Log(playerfu.GetComponentInChildren<Rigidbody2D>().transform.position.x);
        // Debug.Log(playerfu.transform.position);
       // Debug.Log(playerfu.GetComponentInChildren<Rigidbody2D>().transform.position);
        if (playerfu.GetComponentInChildren<Rigidbody2D>().transform.position.x > left && playerfu.GetComponentInChildren<Rigidbody2D>().transform.position.x < right)
        {
            
            inrange = true;
            
            if ( playerfu.gameObject.CompareTag("Player") && zhunbei )
            {
               // Debug.Log(playerfu.GetComponentInChildren<Rigidbody2D>().transform.position.x);
                counts = true;
            }
        }
        else
        {
            inrange = false;
        }

    }
    

    public void AttackToWalk()
    {
        if (timer <= 0)
        {
            anima.SetBool("Attack2", false);
            //anima.Play("Walk");
        }
        else
            timer -= Time.deltaTime;
    }

    public void CD()
    {
        if (lengque <= 0)
            zhunbei = true;
        else
            lengque -= Time.deltaTime;
    }

    public void DoAttack()
    {
        if (yanchi > 1f )
        {
           
            Attack();
        }
        if (counts)
        {
            yanchi += Time.deltaTime;
        }
    }

    public void Attack()
    {

        AttackAS.Play();
        anima.SetBool("Attack2", true);
        //Debug.Log(anima.GetBool("Attack2"));
        //GameObject GO =  Instantiate(yun, weizhi.transform.position, Quaternion.identity);

        timer = 1f;

        zhunbei = false;

        lengque = 5f;

        yanchi = 0;

        counts = false;

        if (anima.GetBool("Attack2") && !anima.GetBool("Attack"))
        {
            CreatTimerBegin = true;

        }
       
       

        if (inrange)
            Debug.Log("放云");
    }
    public void CreatY()
    {
        if (CreatTimer > 0.5)
        {
            GameObject GO = Instantiate(yun, weizhi.transform.position, Quaternion.identity);
            CreatTimer = 0;
            CreatTimerBegin = false;
        }
        if (CreatTimerBegin)
        {
            CreatTimer += Time.deltaTime;
        }
    }
}
