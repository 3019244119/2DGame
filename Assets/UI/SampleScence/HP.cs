using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public static HP instance { get; private set; }

    public Image thisimage;
    private float maxhp = 100f;
    public float newhp = 100f;
    public Text thistext;
    // Start is called before the first frame update
    void Start()
    {
        thisimage = this.GetComponent<Image>();

    }
    public void changehp(float hurt)
    {
        newhp -= hurt;
        thisimage.fillAmount = newhp / maxhp;
        if (newhp > 50f)
        {
            thisimage.color = new Color(0.3f,1f,0.5f);

        }
        if (newhp == 50f)
        {
            thisimage.color = new Color(1, 1, 0);
        }
        if (newhp < 50f)
        {
            thisimage.color = new Color(1, (newhp / 50f), 0, 1);
        }
        if (newhp <= 0)
        {

            SceneManager.LoadScene("Menu");

        }


    }
    // Update is called once per frame
    void Update()
    {
        changehp(0);
    }
}
