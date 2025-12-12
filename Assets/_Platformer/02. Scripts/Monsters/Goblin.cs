using UnityEngine;

namespace Platformer
{
    public class Goblin : Monster
    {
        private Vector2 moveDir;
        
        private float idleTime;
        private float patrolTime;
        private float attackTime;

        private float traceDistance;
        private float attackDistance;
        
        void Start()
        {
            Init();
        }

        protected override void Idle()
        {
            // 가만히 있는 기능
            // 몇 초동안 가만히 있을 것인지?
        }

        protected override void Patrol()
        {
            // 돌아다니는 기능
            // 몇 초동안 돌아다닐 것인지?
            // 어떤 방향으로 이동할 것인지? -> 오른쪽 / 왼쪽
            // 이동속도
            // 정찰 중에 타겟을 확인할 수 있는 거리
        }

        protected override void Trace()
        {
            // 타겟을 쫓아다니는 기능
            // 타겟
            // 추격 중에 타겟을 쫓아갈 수 있는 거리
        }

        protected override void Attack()
        {
            // 타겟을 공격하는 기능
            // 타겟
            // 공격할 수 있는 거리
            // 공격 데미지
            // 공격 쿨타임
        }
    }
}