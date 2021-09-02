using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIController : Controller
{
    public float JumpForce;
    public int Impulse;
    public float MoveSpeed;
    public float HitSpeed;
    public bool isHit;
    public bool isAttack;
    public bool isGround;
    public bool isPause;
    public bool isJump;
    public bool isShooting;
    public bool Shootable;
    private float input;
    private Vector2 dir;
    private bool toAttack;
    private int JumpTimes;

    public LayerMask mask;
    public Vector3 CheckPoint;

    public AudioSource Jump_sd;


    public GameObject Bullet;
    public Animator MyAnimator;
    public Rigidbody2D MyRigidbody;
    private SpriteRenderer sp;
    private PlayerController pc;
    // Start is called before the first frame update
    //wk
    //public int spark;
    //public Text Sparknumber;


    public override void Start()
    {
        base.Start();
        Jump_sd = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        MyAnimator.SetFloat("Horizontal", input * MoveSpeed);
        isGround = Physics2D.OverlapCircle(new Vector2(transform.position.x + CheckPoint.x, transform.position.y + CheckPoint.y), CheckPoint.z, mask);
        if (isGround)
        {
            JumpTimes = 1;
        }
        isJump = Input.GetButtonDown("Jump");

        
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            toAttack = true;
        }
        else
        {
            toAttack = false;
        }
        Attack();
        Shoot();
    }

    public override void Move()
    {
        if (!isJump && !isHit && !isAttack)
        {
            MyRigidbody.velocity = new Vector2(MoveSpeed * input, MyRigidbody.velocity.y);
        }

        if (isHit)
        {
            MyRigidbody.velocity =new Vector2 (HitSpeed * dir.x, MyRigidbody.velocity.y);
        }

        if (isJump && (isGround || JumpTimes > 0))
        {
            if (!isGround)
            {
                JumpTimes--;
            }
            isJump = true;
            Jump_sd.Play();
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, JumpForce);
            MyAnimator.SetTrigger("Jump");
            isJump = false;
        }

        if (MyRigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (MyRigidbody.velocity.y > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }

    public override void Attack()
    {
        if (!isAttack && !isHit && toAttack)
        {
            isAttack = true;
            MyAnimator.SetTrigger("Eat");
        }
    }

    public void GetHeal()
    {
        MyAnimator.SetTrigger("Heal");
        GetHit(-20.0f);
    }

    public override void GetHit(float damage)
    {
        base.GetHit(damage);
        if (!isShooting)
        {
            if (damage > 0)
            isHit = true;
            MyAnimator.SetTrigger("Hit");
        }
       
    }

    public void GetHitOver()
    {
        isHit = false;
        isAttack = false;
    }

    public void AttackOver()
    {
        isAttack = false;
        isHit = false;
    }

    void Shoot()
    {

        if (Shootable && !isHit && !isAttack)
        {
            if (Input.GetMouseButtonDown(1))
            {
                isShooting = true;
                Time.timeScale = 0.1f;
            }
            if (Input.GetMouseButtonUp(1))
            {
                MyRigidbody.velocity = new Vector2(0, 0);
                Time.timeScale = 1.0f;
                Vector3 dir3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                Vector2 dir2 = new Vector2(dir3.x, dir3.y);
                Vector2 dir = dir2.normalized;
                GameObject Go = Instantiate(Bullet, transform.position, Quaternion.identity);
                Go.GetComponent<Bullet>().ShootPosition = transform;
                Go.GetComponent<Bullet>().towards = new Vector3(dir.x, dir.y, 0);
                //Myrigidbody.velocity = -dir * JumpForce * 3;
                Debug.Log(-dir);
                MyRigidbody.AddForce(-dir * Impulse, ForceMode2D.Impulse);
                sp.color = Color.white;
                isShooting = false;
                Shootable = false;
             
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="DeadLine")
        {
            GetComponent<AudioSource>().enabled =false;
            Invoke("Restart", 1f);
        }
        if (isAttack && collision.CompareTag("Bullet"))
        {

            //AttackSense.Instance.CameraShake(0.1f, 0.015f);
            Shootable = true;
            Destroy(collision.gameObject);
            Debug.Log("EATEN");
            //sp.color = Color.red;
            sp.color = new Color(0.9f, 0.1f, 0.3f);
           
        }
        else if (isAttack && collision.CompareTag("Enemy"))
        {
            
            /*
            if (collision.GetComponent<EnemyAI>().current_health / collision.GetComponent<Enemy>().health <= 0.2f)
            {
                
                Destroy(collision.gameObject);
                pc.EnableCharacter = collision.GetComponent<Enemy>().type;
            }
            */
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttack && collision.CompareTag("Bullet"))
        {

            //AttackSense.Instance.CameraShake(0.1f, 0.015f);
            Shootable = true;
            Destroy(collision.gameObject);
            Debug.Log("EATEN");
            //sp.color = Color.red;
            sp.color = new Color(0.9f, 0.1f, 0.3f);

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            if (collision.transform.GetComponent<Bullet>().owner == Owner.Enemy)
            {
                if (collision.transform.position.x >= transform.position.x)
                {
                    dir = new Vector2(-1, 0);
                }
                else
                {
                    dir = new Vector2(1, 0);
                }
                GetHit(2);
            }
            
        }

        if (collision.transform.CompareTag("door"))
        {
            int x = collision.transform.GetComponent<Door>().type;
            transform.position = collision.transform.GetComponent<Door>().another.position + new Vector3(1.0f * x ,0,0);
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            if (collision.transform.GetComponent<EnemyAI>().isAttack)
            {
                GetHit(5);
            }
        }

        if (collision.transform.CompareTag("Heart"))
        {
            pc.ChangeCharacter(CharacterType.Black);
            Destroy(collision.transform.gameObject);
        }

        if (collision.transform.CompareTag("Heal"))
        {
            Destroy(collision.transform.gameObject);
            GetHeal();
        }

        if (collision.transform.CompareTag("spark"))
        {
            Destroy(collision.transform.gameObject);
            //spark++;
            //Sparknumber.text=spark.ToString();
            pc.sparknumber();
        }

    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + CheckPoint.x, transform.position.y + CheckPoint.y), CheckPoint.z);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
