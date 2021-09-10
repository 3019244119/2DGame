using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpRestartUI : MonoBehaviour
{

    public GameObject HelpC;
    public string NowScene;
    // Start is called before the first frame update
    void Start()
    {
        NowScene = SceneManager.GetActiveScene().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CaiDan");
        HelpC.SetActive(false);
    }
}
