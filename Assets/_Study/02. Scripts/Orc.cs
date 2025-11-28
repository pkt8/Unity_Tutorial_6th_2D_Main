using UnityEngine;

namespace OOP
{
    public class Orc : Monster, IMeleeAttack, IRangeAttack
    {
        public float MeleeDamage { get; set; }
        public float RangeDamage { get; set; }
        
        protected override void Attack()
        {
            Debug.Log("기본 공격");
        }
        
        public void MeleeAttack()
        {
            Debug.Log("근접 공격");
        }
        
        public void RangeAttack()
        {
            Debug.Log("원거리 공격");
        }
    }
}