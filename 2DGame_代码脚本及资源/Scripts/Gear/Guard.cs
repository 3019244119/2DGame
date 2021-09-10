using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Vector3 towards;
    public Transform target;
    public Vector3 position;
    public float timer = 0;
    public float interval;
    public float attacktimer = 0;
    public float attackinterval;

    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            position = target.position;
        transform.Translate(towards * Time.deltaTime,Space.World);
        timer += Time.deltaTime;
        if (attacktimer < attackinterval)
        {
            attacktimer += Time.deltaTime;
        }
        
        if (timer > interval)
        {
            timer = 0;
            towards = -towards;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && attacktimer >= attackinterval)
        {
            Debug.Log("attack");
            target = collision.transform;
            Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            float angle = Vector2.Angle(new Vector2(-0.85f, -0.94f), dir);
            float normal = Vector2.Dot(new Vector2(-0.85f, -0.94f), dir);
            if (normal > 0)
            {
                angle *= -1;
            }
            transform.Rotate(new Vector3(0, 0, 1), angle);
            GameObject Go = Instantiate(Bullet, transform.position, Quaternion.identity);
            Go.GetComponent<Ray>().ShootPosition = transform;
            Go.GetComponent<Ray>().towards = new Vector3(target.position.x, target.position.y, 0);
            attacktimer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("instay");
        
        if (collision.CompareTag("Player") && attacktimer >= attackinterval)
        {
            Debug.Log("attack");
            target = collision.transform;
            Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            float angle = Vector2.Angle(new Vector2(-0.85f, -0.94f), dir);
            float normal = Vector2.Dot(new Vector2(-0.85f, -0.94f), dir);
            if (normal > 0)
            {
                angle *= -1;
            }
            transform.Rotate(new Vector3(0, 0, 1), angle);
            GameObject Go = Instantiate(Bullet, transform.position, Quaternion.identity);
            Go.GetComponent<Ray>().ShootPosition = transform;
            Go.GetComponent<Ray>().target = target.position;
            //Go.GetComponent<Ray>().towards = new Vector3(target.position.x, target.position.y, 0);
            attacktimer = 0;
        }
    }
}
