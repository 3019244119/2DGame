using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoss : MonoBehaviour
{

    public BringerCtrl BossC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        BossC.CanKill = true;
        Destroy(gameObject);
        Debug.Log("����ɱboss��");

    }
}
