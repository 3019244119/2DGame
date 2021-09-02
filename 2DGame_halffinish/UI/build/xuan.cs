using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class xuan : MonoBehaviour
{
    public Image thisimage;
    public Transform routeconton;
    public Vector3 routexyz;
    public float routespeed;
    // Start is called before the first frame update
    void Start()
    {
        thisimage = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        thisimage.transform.RotateAround(routeconton.position, routexyz, Time.deltaTime * routespeed);

    }
}
