using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class Wait : MonoBehaviour
{
    public Animator MyAnimator;
    public int hittimes = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet") && collision.transform.GetComponent<Bullet>().owner==Owner.Player)
        {
            hittimes--;
            MyAnimator.SetInteger("Times", hittimes);
        }
       
    }


}
