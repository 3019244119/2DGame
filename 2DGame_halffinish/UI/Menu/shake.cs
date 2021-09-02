using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    private float alpha0 = 0.2f;
    private float alphaspeed = 2.0f;
    private bool isshow;
    private CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        cg = this.transform.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isshow)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, alpha0, alphaspeed * Time.deltaTime);
            if (Mathf.Abs(alpha0 - cg.alpha) <= 0.01)
            {
                isshow = true;
                cg.alpha = alpha0;
                alpha0 = 1;
            }
        }
        else
        {
            cg.alpha = Mathf.Lerp(cg.alpha, alpha0, alphaspeed * Time.deltaTime);
            if (Mathf.Abs(alpha0 - cg.alpha) <= 0.01)
            {
                isshow = false;
                cg.alpha = alpha0;
                alpha0 = 1;
            }
        }
    }

}
