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
    
    
    void Start()
    {
        facedirction = -1;
        left = leftpoint.transform.position.x;
        right = rightpoint.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        if(Input.GetKey(KeyCode.O))
        anima.Play("Attack");
        if (Input.GetKey(KeyCode.I))
            anima.Play("Walk");



    }
    public void MoveL()
    {
        transform.localScale = new Vector3(1, 1, 1);

        ri.velocity = new Vector2(-1*speed, 0);

        anima.SetBool("Walk", true);
       

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


}
