using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

   


public class Fhudong : MonoBehaviour

{
    public GameObject tipscanve;
    // Start is called before the first frame update
    void Start()
    {
        tipscanve.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
       if(Input.GetKey(KeyCode.F))
        {
            Debug.Log("in");
            tipscanve.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        tipscanve.SetActive(false);
    }
}
