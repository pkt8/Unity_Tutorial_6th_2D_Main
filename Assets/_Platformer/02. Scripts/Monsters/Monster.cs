using UnityEngine;

namespace Platformer
{
    public abstract class Monster : MonoBehaviour
    {
        public enum MonsterState { Idle, Patrol, Trace, Attack }
        public MonsterState monsterState = MonsterState.Idle;

        private Transform target;
        
        private Animator anim;
        private Rigidbody2D rb;
        private Collider2D coll;

        [SerializeField] protected MonsterDataSO monsterData;
        
        protected float hp, maxHp;
        protected float moveSpeed;
        protected float damage;
        
        protected float distance;

        protected virtual void Init()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();

            gameObject.name = monsterData.name;
            hp = monsterData.hp;
            maxHp = monsterData.hp;
            moveSpeed = monsterData.moveSpeed;
            damage = monsterData.damage;

            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected abstract void Idle();
        protected abstract void Patrol();
        protected abstract void Trace();
        protected abstract void Attack();
        
        void Update()
        {
            distance = Vector3.Distance(transform.position, target.position);
            
            switch (monsterState)
            {
                case MonsterState.Idle:
                    Idle();
                    break;
                case MonsterState.Patrol:
                    Patrol();
                    break;
                case MonsterState.Trace:
                    Trace();
                    break;
                case MonsterState.Attack:
                    Attack();
                    break;
            }
        }

        protected void ChangeState(MonsterState newState)
        {
            if (monsterState != newState)
            {
                monsterState = newState;
            }
        }
    }
}