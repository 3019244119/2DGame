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

    public float timer;
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
        anima.Play("Attack");

        timer = 0.7f;

        zhunbei = false;

        lengque = 2f;

        yanchi = 0;

        counts = false;

        if (inrange)
            Debug.Log("命中了，打中了");
    }
}
