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
                Debug.Log("데미지 적용");

                Destroy(gameObject);
            }
        }
    }
}