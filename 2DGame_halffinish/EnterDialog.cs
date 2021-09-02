using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterwrong,enterright;
    public Text Sparknumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(Sparknumber.text=="4")
            {
                enterright.SetActive(true);
            }
            else
            {
                enterwrong.SetActive(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            enterwrong.SetActive(false);
            enterright.SetActive(false);
        }
    }
}
