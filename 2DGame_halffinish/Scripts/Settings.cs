using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace settings
{
    public enum Owner
    {
        Player,
        Enemy
    }

    [System.Serializable]
    public class Parameter
    {
        public int health;
        public float moveSpeed;
        public float chaseSpeed;
        public float idleTime;
        public Transform[] patrolPoints;
        public Transform[] chasePoints;
        public Transform target;
        public LayerMask targetLayer;
        public Transform attackPoint;
        public float attackArea;
        public Animator animator;
        public bool getHit;
    }

    public enum StateType
    {
        Idle, Patrol, Chase, React, Attack, Hit, Death
    }

    public enum CharacterType
    {
        AI,
        Black,
        nothing
    }
}

