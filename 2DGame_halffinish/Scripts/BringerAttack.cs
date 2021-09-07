using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anima;
    public GameObject point;

    public bool zhunbei = true;
    public bool counts = false;
    public bool inrange = false;
    public bool keyifang = true;
    public bool Phurt = false;

    public HP hp;


    public BringerAttack2 bringerA2;

    public float timer;
    public float hurttimer;
    public float yanchi;
    public float lengque;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttackToWalk();
        CD();
        DoAttack();
        Hurt();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        inrange = true;

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && zhunbei)
        {
            counts = true;
            
        }

        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        inrange = false;
    }

    public void AttackToWalk()
    {
        if (timer <= 0)
        {
            
            anima.SetBool("Attack", false);
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

    public void DoAttack(){
        if(yanchi> 1f)
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
        anima.SetBool("Attack", true);
       // anima.Play("Attack");

        timer = 0.7f;

        zhunbei = false;

        lengque = 2f;

        yanchi = 0;

        counts = false;

        Phurt = true;

        hurttimer = 0.5f;
            
    }

    public void Hurt()
    {
        if (hurttimer <= 0 && Phurt )
        {
           // Debug.Log("检测");
            Phurt = false;

            if (inrange)
            {
                Debug.Log("命中了，打中了");
                hp.changehp(30);

            }


        }
        else
            hurttimer -= Time.deltaTime;
    }
}
