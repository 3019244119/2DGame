using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject PauseC;
    public GameObject HelpC;
    void Start()
    {
        PauseC.SetActive(false);
        HelpC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        Time.timeScale = 0;
        PauseC.SetActive(true);
    }

}
