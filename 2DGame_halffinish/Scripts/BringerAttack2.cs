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

    public Rigidbody2D ri;

    public bool zhunbei = true;
    public bool counts = false;
    public bool inrange = false;
    public bool CreatTimerBegin = false;

    public float timer;
    public float yanchi;
    public float lengque;
    public float CreatTimer;

    public GameObject leftpoint;
    public GameObject rightpoint;

    private float left;
    private float right;

    void Start()
    {

        left = leftpoint.transform.position.x;
        right = rightpoint.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        AttackToWalk();
        CD();
        DoAttack();
        CreatY();

        if(ri.transform.position.x> left &&ri.transform.position.x < right)
        {
            inrange = true;
            if (ri.gameObject.CompareTag("Player") && zhunbei)
            {
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
           
            anima.Play("Walk");
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
        if (yanchi > 1f)
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
        anima.Play("Cast");

        //GameObject GO =  Instantiate(yun, weizhi.transform.position, Quaternion.identity);

        timer = 1f;

        zhunbei = false;

        lengque = 5f;

        yanchi = 0;

        counts = false;

        CreatTimerBegin = true;

        if (inrange)
            Debug.Log("命中了，打中了");
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
