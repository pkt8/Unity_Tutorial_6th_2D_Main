using UnityEngine;

namespace Platformer
{
    public class Goblin : Monster
    {
        private float moveDir;

        private float timer;
        private float idleTime = 3f;
        private float patrolTime = 5f;
        private float attackTime;

        private float traceDistance = 5f;
        private float attackDistance = 2f;
        
        void Start()
        {
            Init();
            attackTime = monsterData.attackTime;
        }

        protected override void Idle()
        {
            timer += Time.deltaTime;
            if (timer >= idleTime)
            {
                timer = 0f;
                patrolTime = Random.Range(0f, 5f);

                int ranNumber = Random.Range(0, 2); // 0 , 1

                if (ranNumber == 0)
                    moveDir = -1;
                else if (ranNumber == 1)
                    moveDir = 1;

                // moveDir = Random.Range(0, 2) == 0 ? -1 : 1;
                
                ChangeState(MonsterState.Patrol);
            }
            
            if (distance <= traceDistance)
            {
                ChangeState(MonsterState.Trace);
            }
        }

        protected override void Patrol()
        {
            transform.position += Vector3.right * moveDir * moveSpeed * Time.deltaTime;
            
            timer += Time.deltaTime;
            if (timer >= patrolTime)
            {
                timer = 0f;
                idleTime = Random.Range(0f, 5f);
                ChangeState(MonsterState.Idle);
            }
            
            if (distance <= traceDistance)
            {
                ChangeState(MonsterState.Trace);
            }
        }

        protected override void Trace()
        {
            if (distance > traceDistance)
            {
                timer = 0f;
                idleTime = Random.Range(0f, 5f);
                
                ChangeState(MonsterState.Idle);
            }
            else if (distance <= attackDistance)
            {
                ChangeState(MonsterState.Attack);
            }
        }

        protected override void Attack()
        {
            if (distance > attackDistance)
            {
                ChangeState(MonsterState.Trace);
            }
        }
    }
}