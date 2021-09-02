using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;

public class BlackController : Controller
{
    [Header("补偿速度")]
    public float lightSpeed;
    public float heavySpeed;
    [Header("打击感")]
    public float shakeTime;
    public int lightPause;
    public float lightStrength;
    public int heavyPause;
    public float heavyStrength;
    public bool isAttack;
    public bool isGround;
    public bool isHit;

    [Space]
    public float interval = 1f;
    private float timer;

    private string attackType;
    private int comboStep = 0;

    public float moveSpeed;
    public float jumpForce;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private float input;

    [SerializeField] private LayerMask layer;

    [SerializeField] private Vector3 check;
    public Transform AttackArea;
    public float Attackradius;
    public AudioSource hit;

    public override void Start()
    {
        hit = GetComponent<AudioSource>();
        base.Start();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        isGround = Physics2D.OverlapCircle(transform.position + new Vector3(check.x, check.y, 0), check.z, layer);

        animator.SetFloat("Horizontal", rigidbody.velocity.x);

        Move();
        Attack();
    }

    public override void Move()
    {
        if (!isAttack)
            rigidbody.velocity = new Vector2(input * moveSpeed, rigidbody.velocity.y);
        else
        {
            if (attackType == "Light")
                rigidbody.velocity = new Vector2(-transform.localScale.x * lightSpeed, rigidbody.velocity.y);
            else if (attackType == "Heavy")
                rigidbody.velocity = new Vector2(-transform.localScale.x * heavySpeed, rigidbody.velocity.y);
        }

        
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigidbody.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");
        }
        
        if (!isAttack)
        {
            if (rigidbody.velocity.x < 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (rigidbody.velocity.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttack)
        {
            hit.Play();
            isAttack = true;
            
            if (comboStep > 2)
            {
                comboStep = 0;
            }

            if (comboStep == 0)
            {
                attackType = "Light";
            }
            else
            {
                attackType = "Height";
            }
            timer = interval;
            animator.SetTrigger("Attack");
            
            animator.SetInteger("Combo", comboStep);
            comboStep++;
        }
        


        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                comboStep = 0;
            }
        }

    }

    public void AttackOver()
    {
        isAttack = false;
    }

    public override void GetHit(float damage)
    {
        base.GetHit(damage);
        isHit = true;
        animator.SetTrigger("Hit");
    }

    public void GetHitOver()
    {
        isHit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && isAttack)
        {
            if (attackType == "Light")
            {
                AttackEffect.Instance.HitPause(lightPause);
                AttackEffect.Instance.CameraShake(shakeTime, lightStrength);
            }
            else if (attackType == "Heavy")
            {
                AttackEffect.Instance.HitPause(heavyPause);
                AttackEffect.Instance.CameraShake(shakeTime, heavyStrength);
            }

            other.GetComponent<EnemyAI>().parameter.getHit = true;

            if (transform.localScale.x > 0)
                other.GetComponent<EnemyAI>().GetHit();
            else if (transform.localScale.x < 0)
                other.GetComponent<EnemyAI>().GetHit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(check.x, check.y, 0), check.z);
        Gizmos.DrawWireSphere(AttackArea.position, Attackradius);
    }
}