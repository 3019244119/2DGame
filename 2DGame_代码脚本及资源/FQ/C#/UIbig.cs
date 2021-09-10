using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using settings;



public class UIbig : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public float big;
    
    public Rigidbody2D Pri;
    public GameObject playerfu;

    public Animator anmia;
    public bool Isboss = true;
    public bool CanKill = false;
     
    


    void Start()
    {
        //
        Debug.Log("被子弹打了");
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(big, big, big);
        // Debug.Log("in");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

   

}
