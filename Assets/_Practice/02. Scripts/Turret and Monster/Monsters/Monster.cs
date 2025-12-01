using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Turret
{
    public class Monster : MonoBehaviour, IDamageable
    {
        private Animator anim;
        private Rigidbody rb;
        private Collider coll;

        private List<TurretController> turrets = new List<TurretController>();

        [SerializeField] protected Transform hpUI;
        [SerializeField] protected Image hpBar;
        private Transform mainCamera;

        protected float hp; // 현재 체력
        private float maxHp; // 최대 체력
        protected float moveSpeed;

        private bool isMove = true;

        protected virtual void Init(float hp, float moveSpeed)
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<Collider>();

            mainCamera = Camera.main.transform;

            this.hp = hp;
            this.moveSpeed = moveSpeed;

            maxHp = hp;
        }

        void FixedUpdate()
        {
            if (!isMove)
                return;

            rb.linearVelocity = Vector3.right * moveSpeed;
        }

        void Update()
        {
            hpUI.LookAt(mainCamera);
        }
        
        public void GetDamage(float damage, TurretController turret)
        {
            if (!turrets.Contains(turret))
                turrets.Add(turret);

            StartCoroutine(HitRoutine(damage));
        }

        IEnumerator HitRoutine(float damage)
        {
            hp -= damage;
            hpBar.fillAmount = hp / maxHp;
            
            anim.SetTrigger("Damage");
            isMove = false;

            if (hp <= 0)
            {
                Death();
            }
            else // h > 0
            {
                yield return new WaitForSeconds(0.5f);
                isMove = true;
            }
        }

        public void Death()
        {
            anim.SetTrigger("Dead");
            isMove = false;
            coll.enabled = false;
            rb.isKinematic = true;

            foreach (TurretController turret in turrets)
                turret.SetTarget(transform);
                
            Destroy(gameObject, 3f);
        }
    }
}