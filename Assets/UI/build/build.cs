using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class build : MonoBehaviour
{
    public Text textmange;
    // public Image imagemange;
    private int currentnumbers = 0;
    void Updatenumbers()
    {
        int sumnumber = 1000;
        if (currentnumbers < sumnumber)
        {
            currentnumbers++;
        }
        textmange.text = "LOADING..." + currentnumbers / 10 + "%";
        // imagemange.fillAmount = currentnumbers / 1000f;
        if (currentnumbers == 1000)
        {
            textmange.text = "COMPLETE  OK ";
            SceneManager.LoadScene("Menu");
        }
    }
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Updatenumbers();
    }
}
