using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingHelpBack : MonoBehaviour

{

    public GameObject HelpC;
    public GameObject PauseC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        HelpC.SetActive(false);
        PauseC.SetActive(true);
    }
}
