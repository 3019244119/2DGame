using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float timer = 0;
    public float interval = 2.0f;
    public float speed = 3;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > interval)
        {
            speed = -speed;
            rig.velocity = new Vector2(speed, 0);
            timer = 0;
        }
    }
}
