using System;
using UnityEngine;

namespace Turret
{
    public class TurretController : MonoBehaviour
    {
        private Transform turretHead;

        public Transform target;

        public float angle = 60f; // 회전 각도 60도
        public float rotSpeed = 0.5f; // 회전 속도

        private float theta;

        void Start()
        {
            turretHead = transform.GetChild(0);
        }

        void Update()
        {
            if (target != null) // Target이 있을 때
            {
                Shoot();
            }
            else // Target이 없을 때
            {
                Turn();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                target = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                target = null;
            }
        }

        // Target이 없을 때 주변을 둘러보는 기능
        private void Turn()
        {
            theta += Time.deltaTime * rotSpeed;

            float rotationAngle = Mathf.Sin(theta) * angle;

            turretHead.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }

        // Target이 있을 때 대상을 바라보는 기능
        private void Shoot()
        {
            turretHead.LookAt(target);
        }
    }
}