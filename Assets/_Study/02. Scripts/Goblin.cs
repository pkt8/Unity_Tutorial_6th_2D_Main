using UnityEngine;

namespace OOP
{
    public class Goblin : Monster
    {
        void Start()
        {
            Shout();

            Attack();
        }
        
        public override void Attack()
        {
            Debug.Log("독 단검으로 공격");
        }
        
        public override void Shout()
        {
            base.Shout();
            Debug.Log("고블 고블");
        }
    }
}