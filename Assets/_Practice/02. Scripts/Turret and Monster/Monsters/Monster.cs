using System.Collections;
using UnityEngine;

namespace Turret
{
    public class Monster : MonoBehaviour
    {
        private Animator anim;
        private Rigidbody rb;
        private Collider coll;

        protected float hp;
        protected float moveSpeed;

        private bool isMove = true;

        protected virtual void Init(float hp, float moveSpeed)
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<Collider>();

            this.hp = hp;
            this.moveSpeed = moveSpeed;
        }

        void FixedUpdate()
        {
            if (!isMove)
                return;

            rb.linearVelocity = Vector3.right * moveSpeed;
        }

        public void GetDamage(float damage)
        {
            StartCoroutine(HitRoutine(damage));
        }

        IEnumerator HitRoutine(float damage)
        {
            hp -= damage;
            anim.SetTrigger("Damage");
            isMove = false;

            if (hp <= 0)
            {
                // 나를 쏘던 터렛에게 타겟 재설정 필요
                
                anim.SetTrigger("Dead");
                isMove = false;
                coll.enabled = false;
                rb.isKinematic = true;

                yield return new WaitForSeconds(3f);
                Destroy(gameObject);
            }
            else // h > 0
            {
                yield return new WaitForSeconds(0.5f);
                isMove = true;
            }
        }
    }
}