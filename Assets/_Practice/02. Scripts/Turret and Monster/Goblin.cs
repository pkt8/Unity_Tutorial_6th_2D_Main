using UnityEngine;

namespace Turret
{
    public class Goblin : MonoBehaviour
    {
        private Animator anim;
        private Rigidbody rb;
        private CapsuleCollider coll;

        [SerializeField] private float hp = 3f;
        [SerializeField] private float moveSpeed = 0.05f;

        private bool isMove = true;

        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<CapsuleCollider>();
        }

        void FixedUpdate()
        {
            if (!isMove)
                return;

            rb.linearVelocity = Vector3.right * moveSpeed;
        }

        public void GetDamage(float damage)
        {
            hp -= damage;
            anim.SetTrigger("Damage");

            if (hp <= 0)
            {
                anim.SetTrigger("Dead");
                isMove = false;
                coll.enabled = false;
                rb.isKinematic = true;
            }
        }
    }
}