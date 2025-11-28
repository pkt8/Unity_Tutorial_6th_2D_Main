using UnityEngine;

namespace OOP
{
    public class Orc : Monster
    {
        void Start()
        {
            Shout();

            Attack();
        }
        
        public override void Attack()
        {
            Debug.Log("양손 도끼로 범위 공격");
        }
        
        public override void Shout()
        {
            base.Shout();
            Debug.Log("오크 오크");
        }
    }
}