using System;
using UnityEngine;

namespace Turret
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        // 몬스터에 닿았을 때 데미지를 적용하는 기능
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
                if (other.GetComponent<Goblin>())
                {
                    Goblin monster = other.GetComponent<Goblin>();
                    monster.GetDamage(damage);

                    Destroy(gameObject);
                }
                else if (other.GetComponent<HobGoblin>())
                {
                    HobGoblin monster = other.GetComponent<HobGoblin>();
                    monster.GetDamage(damage);

                    Destroy(gameObject);
                }
            }
        }
    }
}