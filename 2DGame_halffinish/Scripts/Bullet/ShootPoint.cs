using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public bool isfollowing;
    public Vector2 towards;
    public GameObject bullet;
    private float timer;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            Shooting(towards);
        }
    }

    void Shooting(Vector2 towards)
    {
        GameObject Go = Instantiate(bullet, transform.position, Quaternion.identity);
        Go.GetComponent<Bullet>().ShootPosition = transform;
        Go.GetComponent<Bullet>().towards = new Vector3(towards.x, towards.y, 0);
    }
}
