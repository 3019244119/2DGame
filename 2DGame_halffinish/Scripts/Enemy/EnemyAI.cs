using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using settings;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public Parameter parameter;
    public StateType currentState;
    public CharacterType type;
    public Vector2 speed;
    public bool isAttack;
    public Transform DamageCircle;
    public float Damageradius;
    public GameObject heart;

    private float Attacktimer;
    public float interval = 1.2f;
    //public AudioSource hit;

    private float timer;
    private AnimatorStateInfo info;
    private Rigidbody2D rig;
    private int patrolPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        //hit = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        currentState = StateType.Idle;
        parameter.animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Attacktimer < interval)
        {
            Attacktimer += Time.deltaTime;
        }
        if (!(currentState==StateType.Attack))
        rig.velocity = speed;
        OnUpdate();
    }


    public void GetHit()
    {

        parameter.getHit = true;
    }

    void OnEnter()
    {
        switch (currentState)
        {
            case StateType.Idle:
                Debug.Log("EnterIdle");
                rig.velocity = new Vector2(0, 0);
                parameter.animator.Play("Idle");
                break;

            case StateType.Patrol:
                parameter.animator.Play("Walk");
                FlipTo(parameter.patrolPoints[patrolPosition]);
                break;

            case StateType.React:

                break;

            case StateType.Chase:
                parameter.animator.Play("Walk");
                break;

            case StateType.Attack:
                if (Attacktimer >= interval)
                {
                    isAttack = true;
                    //hit.Play();
                    Attacktimer = 0;
                    if (!parameter.getHit)
                    {
                        rig.velocity = new Vector2(0, 0);
                        parameter.animator.Play("Attack");
                        if (Physics2D.OverlapCircle(new Vector2(DamageCircle.position.x, DamageCircle.position.y), Damageradius, parameter.targetLayer) && isAttack)
                        {
                            parameter.target = Physics2D.OverlapCircle(
                                new Vector2(DamageCircle.position.x, DamageCircle.position.y),
                                Damageradius, parameter.targetLayer).transform;
                            if (parameter.target != null)
                            {
                                try
                                {
                                    parameter.target.GetComponent<Controller>().GetHit(2);
                                }
                                catch
                                {
                                    parameter.target = Physics2D.OverlapCircle(
                                new Vector2(DamageCircle.position.x, DamageCircle.position.y),
                                Damageradius, parameter.targetLayer).transform;
                                }
                            }
                        }
                    
                        
                    }
                }
                
                break;

            case StateType.Hit:
                parameter.animator.Play("Hit");
                parameter.health--;
                break;

            case StateType.Death:
                Instantiate(heart, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                Destroy(gameObject);
                break;


        }
    }

    void OnUpdate()
    {
        switch (currentState)
        {
            //IDLE
            case StateType.Idle:
                timer += Time.deltaTime;

                if (parameter.getHit)
                {
                    TransitionState(StateType.Hit);
                }
                if (parameter.target != null &&
                    parameter.target.position.x >= parameter.chasePoints[0].position.x &&
                    parameter.target.position.x <= parameter.chasePoints[1].position.x)
                {
                    TransitionState(StateType.React);
                }
                if (timer >= parameter.idleTime)
                {
                    TransitionState(StateType.Patrol);
                }
                break;
            //PATROL
            case StateType.Patrol:
                

                //transform.position = Vector2.MoveTowards(transform.position,
                //parameter.patrolPoints[patrolPosition].position, parameter.moveSpeed * Time.deltaTime);

                

                if (parameter.getHit)
                {
                    TransitionState(StateType.Hit);
                }
                if (parameter.target != null &&
                    parameter.target.position.x >= parameter.chasePoints[0].position.x &&
                    parameter.target.position.x <= parameter.chasePoints[1].position.x)
                {
                    TransitionState(StateType.React);
                }
                if (Vector2.Distance(transform.position, parameter.patrolPoints[patrolPosition].position) < 1.0f)
                {
                    Debug.Log("arrive");
                    TransitionState(StateType.Idle);
                }
                break;

            //REACT
            case StateType.React:
                info = parameter.animator.GetCurrentAnimatorStateInfo(0);

                if (parameter.getHit)
                {
                    TransitionState(StateType.Hit);
                }
                if (info.normalizedTime >= .95f)
                {
                    TransitionState(StateType.Chase);
                }
                break;

            //CHASE
            case StateType.Chase:
                FlipTo(parameter.target);
                if (parameter.target)
                {
                    /*
                    transform.position = Vector2.MoveTowards(transform.position,
                    parameter.target.position, parameter.chaseSpeed * Time.deltaTime);
                    */
                    FlipTo(parameter.target);
                }
                    

                if (parameter.getHit)
                {
                    TransitionState(StateType.Hit);
                }
                if (parameter.target == null ||
                    transform.position.x < parameter.chasePoints[0].position.x ||
                    transform.position.x > parameter.chasePoints[1].position.x)
                {
                    TransitionState(StateType.Idle);
                }
                if (Physics2D.OverlapCircle(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer))
                {
                    TransitionState(StateType.Attack);
                }
                break;
            //ATTACK
            case StateType.Attack:
                info = parameter.animator.GetCurrentAnimatorStateInfo(0);

                if (parameter.getHit)
                {
                    TransitionState(StateType.Hit);
                }
                if (info.normalizedTime >= .95f)
                {
                    TransitionState(StateType.Chase);
                }
                break;
            //HIT
            case StateType.Hit:
                info = parameter.animator.GetCurrentAnimatorStateInfo(0);

                if (parameter.health <= 0)
                {
                    TransitionState(StateType.Death);
                }
                if (info.normalizedTime >= .95f)
                {
                    parameter.target = GameObject.FindWithTag("Player").transform;

                    TransitionState(StateType.Chase);
                }
                break;

            case StateType.Death:

                break;


        }
    }

    void OnExit()
    {
        switch (currentState)
        {
            case StateType.Idle:
                timer = 0;
                break;
            case StateType.Patrol:
                Debug.Log("PatrolExit");
                patrolPosition++;

                if (patrolPosition >= parameter.patrolPoints.Length)
                {
                    patrolPosition = 0;
                }
                break;
            case StateType.React:

                break;
            case StateType.Chase:

                break;
            case StateType.Attack:

                break;

            case StateType.Hit:
                parameter.getHit = false;
                break;

            case StateType.Death:

                break;


        }
    }


    void TransitionState(StateType type)
    {
        OnExit();
        currentState = type;
        OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                speed = new Vector2(-1 * (float)parameter.moveSpeed,0);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                speed = new Vector2(1 * (float)parameter.moveSpeed, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            parameter.target = other.transform;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
        Gizmos.DrawWireSphere(DamageCircle.position, Damageradius);
    }

    void AttackOver()
    {
        isAttack = false;
    }

    void GetHitOver()
    {

    }


}
