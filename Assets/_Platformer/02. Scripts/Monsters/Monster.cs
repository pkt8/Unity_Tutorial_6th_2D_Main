using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Platformer
{
    public abstract class Monster : MonoBehaviour, IDamageable
    {
        public enum MonsterState { Idle, Patrol, Trace, Attack }
        public MonsterState monsterState = MonsterState.Idle;

        private ItemManager itemManager;
        
        protected Transform target;
        
        protected Animator anim;
        private Rigidbody2D rb;
        private Collider2D coll;

        [SerializeField] protected Slider hpSlider;

        [SerializeField] protected MonsterDataSO monsterData;
        
        protected float hp, maxHp;
        protected float moveSpeed;
        protected float damage;
        
        protected int moveDir;
        protected float distance;

        private bool isDead = false;

        protected virtual void Init()
        {
            itemManager = FindFirstObjectByType<ItemManager>();
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();

            gameObject.name = monsterData.name;
            hp = monsterData.hp;
            maxHp = monsterData.hp;
            moveSpeed = monsterData.moveSpeed;
            damage = monsterData.damage;

            target = GameObject.FindGameObjectWithTag("Player").transform;

            hpSlider.value = hp / maxHp;
        }

        protected abstract void Idle();
        protected abstract void Patrol();
        protected abstract void Trace();
        protected abstract void Attack();
        
        void Update()
        {
            if (isDead)
                return;
            
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                // Debug.Log("방향을 반대로 변경");
                moveDir *= -1;
                transform.localScale = new Vector3(moveDir, 1, 1);
                hpSlider.transform.parent.localScale = new Vector3(moveDir, 1, 1);
            }

            var target = other.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(damage);
                
                // Debug.Log($"{gameObject.name}이 {other.name}에게 {damage}만큼의 데미지 적용");
            }
        }

        protected void ChangeState(MonsterState newState)
        {
            if (monsterState != newState)
            {
                monsterState = newState;
            }
        }

        public void TakeDamage(float damage)
        {
            hp -= damage;
            anim.SetTrigger("Hit");
            hpSlider.value = hp / maxHp;
            
            if (hp <= 0)
                Death();
        }

        public void Death()
        {
            int ranCount = Random.Range(0, 3); // 0, 1, 2

            for (int i = 0; i < ranCount; i++)
                itemManager.DropItem(transform.position);
            
            isDead = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            coll.enabled = false;
            anim.SetTrigger("Death");
            Debug.Log($"{gameObject.name} 죽음");

            Invoke(nameof(DelayEvent), 3f);
        }

        private void DelayEvent()
        {
            Destroy(gameObject);
        }
    }
}