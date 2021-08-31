using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        PauseC.SetActive(false);
        Time.timeScale = 1f;

    }
}
