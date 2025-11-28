using UnityEngine;

namespace OOP
{
    public class Dragon : Monster
    {
        void Start()
        {
            Shout();

            Attack();
        }
        
        public override void Attack()
        {
            Debug.Log("화염 브레스로 범위 공격");
        }
        
        public override void Shout()
        {
            base.Shout();
            Debug.Log("드래곤");
        }
    }
}