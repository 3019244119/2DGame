using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGear : MonoBehaviour
{
    public float WarmTimer;
    public float RayTimer;
    public float WarmInterval;
    public float RayInterval;

    
    public bool has = false;

    public GameObject Ray;
    public Animator RayAnimator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!has)
        {
            WarmTimer += Time.deltaTime;
        }
        
        if (WarmTimer > WarmInterval && !has)
        {
            RayAnimator.Play("Ray");
            has = true;
            WarmTimer = 0;
        }

        if (has)
        {
            RayTimer += Time.deltaTime;
            if (RayTimer > RayInterval)
            {
                RayTimer = 0;
                RayAnimator.Play("ori");
                has = false;
            }
        }
    }

    void Delay()
    {
        RayAnimator.Play("RayDelay");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !has)
        {
            collision.GetComponent<Controller>().GetHit(0.05f);
        }
    }


}
