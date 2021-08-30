using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    public float speedh;//X Horizontal
    public float speedv;//Y Vertical
    // S = 2*speed
    public float heng;
    public float shu;
    public float countheng ;
    public float countshu ;

    public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         RandM();
        if(Input.GetKey(KeyCode.L))
        {
            MoveU();
        }
        
    }


    void RandM()
    {
        System.Random rd = new System.Random();
        int x = rd.Next(1, 150);

        if (  Mathf.Abs( rb.velocity.x )<= 0.1 && Mathf.Abs(rb.velocity.y) <= 0.1)
        {
            if (x == 5 && countshu < shu) {
                Debug.Log(transform.position);
                MoveU();  
                }
            if (x == 7 && countshu > -1 * shu) {
                Debug.Log(transform.position);
                MoveD();
            
                }
            if (x == 9 && countheng > -1 * heng)
               {
                Debug.Log(transform.position);
                MoveL();
                }
            if (x == 11 && countheng < heng)
               {
                Debug.Log(transform.position);
                MoveR();
               }
        }

    }

    void MoveU()
    {
        rb.velocity = new Vector2(0, 1)*speedv;
        countshu++;
    }
    void MoveD()
    {

        rb.velocity = new Vector2(0, -1) * speedv;
        countshu--;
    }
    void MoveR()
    {

        transform.localScale = new Vector3(-1, 1, 1);
        rb.velocity = new Vector2(1, 0) * speedh;
        countheng++;

    }
    void MoveL()
    {
        transform.localScale = new Vector3(1, 1, 1);
        rb.velocity = new Vector2(-1, 0) * speedh;
        countheng--;
    }
}
