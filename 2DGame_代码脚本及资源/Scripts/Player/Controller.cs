using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public HP hp;
    // Start is called before the first frame update
    public virtual void Start()
    {
        hp = GameObject.FindGameObjectWithTag("hp").GetComponent<HP>();
        /*SaveManager.instance.activeSave.hp=GameObject.FindGameObjectWithTag("hp").GetComponent<HP>();
*/
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
        SaveManager.instance.activeSave.hp=hp.newhp;
    }
}
