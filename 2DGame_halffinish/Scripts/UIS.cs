using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HelpC;
    void Start()
    {
        HelpC.SetActive(false);
    }
   public void click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        HelpC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
