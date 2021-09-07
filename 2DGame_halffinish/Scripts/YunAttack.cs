using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class YunAttack : MonoBehaviour
{
    // Start is called before the first frame update

    // public float cunzaishijian;
    //  public bool keyixiaohui = true;

    // public Animator anmia;
    // public GameObject playerfu;

    // public Rigidbody2D ri;
    //public Rigidbody2D Pri;

    // public PlayerController PCtrl;
    public float cunzaishijian;
    public float yanchi = 0;
    public float timer = 0;
    public float hurttimer = 0;

    public bool keyixiaohui = true;
    public bool counts = false;
    public bool inrange = false;
    public bool timerbegin = false;
    public bool hurttimerbegin = false;
    public bool canhurt = false;
    public bool finish = false;

    
    public Animator anmia;
    public HP hp;
    //public GameObject playerfu;
    //public GameObject[] play;

    public Rigidbody2D ri;
    //public Rigidbody2D Pri;
   


    public PlayerController PCtrl;
    void Start()
    {
        // playerfu = Pri.transform.parent.gameObject;
      //  Pri = playerfu.GetComponentInChildren<Rigidbody2D>();
       // playerfu = Pri.transform.parent.gameObject;
        
        //  play = GameObject.FindGameObjectsWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        TimerDeaestroy();
        DoAttack();
        ZhuiZong();
        AttackToD();
        Hurt();
        //if (Input.GetKey(KeyCode.P))
        //{
        //    anmia.SetBool("Attack", true);
       // }
    }

    public void TimerDeaestroy()
    {
        if (cunzaishijian <= 0 && keyixiaohui)
        {
            Destroy(gameObject);
        }
        else
        {
            cunzaishijian -= Time.deltaTime;
        }
    }

    public void ZhuiZong()
    {
        //Debug.Log(playerfu.transform.position);
        //Debug.Log(playerfu.GetComponentInChildren<Rigidbody2D>().transform.position);
        // Debug.Log(playerfu.gameObject.GetComponentInChildren<Rigidbody2D>().position);
        //Debug.Log(playerfu.gameObject.GetComponentInChildren<Rigidbody2D>().transform.position);
        //Debug.Log(playerfu.GetComponentInChildren<Rigidbody2D>().transform.localPosition);
        // Debug.Log(playerfu.transform.localPosition);  //-6.6 -2.7 0
        // Transform ts = playerfu.GetComponentInChildren<Transform>();
        // Debug.Log(ts.position);//-6.6 -2.7 0
        GameObject playe = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(playe.GetComponentInChildren<Rigidbody2D>().position);
        // Debug.Log(playerfu.gameObject.GetComponentInParent<Rigidbody2D>().transform.position);
       // Destroy(playe);


        Vector3 Ytowards = new Vector3();
        
        switch (PCtrl.EnableCharacter)
        {
            case CharacterType.AI:
               // Ytowards = (playerfu.GetComponentInChildren<Rigidbody2D>().transform.position - transform.position + new Vector3(0, 0.69f, 0));
                Ytowards = (playe.GetComponentInChildren<Rigidbody2D>().transform.position - transform.position + new Vector3(0, 0, 0));
               // Debug.Log(PCtrl.EnableCharacter);
                break;
            case CharacterType.Black:
              //  Ytowards = (playerfu.GetComponentInChildren<Rigidbody2D>().transform.position - transform.position + new Vector3(0, 0.95f, 0));
                Ytowards = (playe.GetComponentInChildren<Rigidbody2D>().transform.position - transform.position + new Vector3(0, 0.95f, 0));

                break;
        }

       // Debug.Log(playe.GetComponentInChildren<Rigidbody2D>().transform.position);

        ri.velocity = Ytowards  ;


        if (Mathf.Abs(ri.velocity.y) < 0.01 &&!finish)
        {
            
            keyixiaohui = false;
            ri.constraints = RigidbodyConstraints2D.FreezeAll;
            counts = true;

        }

    }

    public void DoAttack()
    {
        if (yanchi > .5f)
        {
            Debug.Log("开始雷击");
            Attack();
        }
        if (counts)
        {
            yanchi += Time.deltaTime;
        }
    }

    public void Attack()
    {
        anmia.SetBool("Attack", true);
        timerbegin = true;
        hurttimerbegin = true;
        canhurt = true;


    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Player"))
        {

            inrange = true;
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            inrange = false;
        }
    }

    public void AttackToD()
    {
        if (timer >= 1.4f)
        {

            Destroy(gameObject);

        }
        if (timerbegin)
            timer += Time.deltaTime;
    }

    public void Hurt()
    {
        if (hurttimer >= 0.5f && canhurt &&inrange)
        {
            canhurt = false;

            Debug.Log("被雷击了");
            GameObject hpGO = GameObject.FindGameObjectWithTag("hp");

            HP hp = hpGO.GetComponent<HP>();

            hp.changehp(40);

            yanchi = 0;

            counts = false;

            finish = true;

        }
        if (hurttimerbegin)
            hurttimer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
       

    }
    




}
