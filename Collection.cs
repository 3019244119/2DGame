using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{

    public AudioSource Ads;

    public float timer = 0;
    public bool timerBegin = false;

    public Animator anima;
    public FXMove fx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyThis();
    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fx = other.gameObject.GetComponent<FXMove>();

            Ads.Play();           // audio 

            // fx.SetScore(10);

            anima.SetBool("Eated", true); // animation
            timerBegin = true;
        }


    }

    void DestroyThis()
    {
        if (timer > 0.45)// after 0.45S destroy collections
        {
            Destroy(gameObject);
            fx.SetScore(10);
        }
        if (timerBegin)
            timer += Time.deltaTime;
    }
}
