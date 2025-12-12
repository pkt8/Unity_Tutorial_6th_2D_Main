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

        [SerializeField] private MonsterDataSO monsterData;
        
        protected float hp, maxHp;
        protected float moveSpeed;
        protected float damage;

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
        }

        protected abstract void Idle();
        protected abstract void Patrol();
        protected abstract void Trace();
        protected abstract void Attack();
        
        void Update()
        {
            float distance = Vector3.Distance(transform.position, target.position);
            
            
            
            
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
    }
}