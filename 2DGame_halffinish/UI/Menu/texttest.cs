using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class texttest : MonoBehaviour
{
    public int time = 0;
    public Text title;
    // Start is called before the first frame update
    void Start()
    {
        title.fontSize = this.gameObject.GetComponent<Text>().fontSize = 56;
    }
    public void changsize()
    {
        if (time < 100 * Time.deltaTime)
        {
            time++;
            title.fontSize = this.gameObject.GetComponent<Text>().fontSize = 41 + 3 * time;
        }
    }
    // Update is called once per frame
    void Update()
    {
        changsize();
    }
}
