using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingHelp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HelpC;
   public GameObject PauseC;
    void Start()
    {
        HelpC.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        PauseC.SetActive(false);
        HelpC.SetActive(true);

    }
}
