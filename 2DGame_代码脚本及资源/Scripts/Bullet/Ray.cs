using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class Ray : MonoBehaviour
{
    public Owner owner;
    public Vector3 towards;
    public float speed;
    public Transform ShootPosition;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        if (ShootPosition != transform)
        {
            Vector3 dir = target - ShootPosition.position;
            towards = dir;
            float rotate = Vector2.Angle(new Vector2(1, 0), new Vector2(dir.x, dir.y));

            if (towards.y < 0)
            {
                rotate *= -1;
            }
            transform.Rotate(new Vector3(0, 0, 1), rotate);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(towards * Time.deltaTime * speed, Space.World);
        if (transform.position.x < -9f || transform.position.x > 67.45 || transform.position.y < -5f || transform.position.y > 6.53f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Controller>().GetHit(2);
            Destroy(gameObject);
        }
    }
}
