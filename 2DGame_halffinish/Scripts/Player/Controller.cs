using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public HP hp;
    // Start is called before the first frame update
    public virtual void Start()
    {
        hp = GameObject.FindGameObjectWithTag("hp").GetComponent<HP>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }

    public virtual void GetHit(float damage)
    {
        hp.changehp(damage);
    }
}
