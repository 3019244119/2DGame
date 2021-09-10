using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class Bullet : MonoBehaviour
{
    public Owner owner;
    public Vector3 towards;
    public float speed;
    public Transform ShootPosition;
    public AudioSource boom;

    public Animator bullet;
    private bool moveable = true;
    // Start is called before the first frame update
    void Start()
    {
        float rotate = Vector2.Angle(new Vector2(1, 0), new Vector2(towards.x, towards.y));

        if (towards.y < 0)
        {
            rotate *= -1;
        }
        transform.Rotate(new Vector3(0, 0, 1), rotate);

        //transform.LookAt(ShootPosition.position + towards);
        bullet.Play("MagicBullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable)
        {
            transform.Translate(towards * Time.deltaTime * speed, Space.World);
            if (transform.position.x < -9f || transform.position.x > 67.45 || transform.position.y < -5f || transform.position.y > 6.53f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && owner == Owner.Enemy)
        {
            moveable = false;
            //boom.Play();
            Destroy(gameObject);
            //OnDisappear();
        }
        else if (collision.transform.tag=="Enemy" && owner == Owner.Player)
        {
            //boom.Play();
            moveable = false;
            collision.transform.GetComponent<EnemyAI>().GetHit();
            Destroy(gameObject);
            //OnDisappear();
        }
        else if (collision.transform.tag == "Ground")
        {
            moveable = false;
            Destroy(gameObject);
            //OnDisappear();

        }
    }
}
