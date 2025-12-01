using System;
using UnityEngine;

namespace Turret
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        public TurretController turret;
        private Rigidbody rb;

        [SerializeField] private float damage = 1f;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                Monster monster =  other.GetComponent<Monster>();
                monster.GetDamage(damage, turret);

                Destroy(gameObject);
            }
        }
    }
}