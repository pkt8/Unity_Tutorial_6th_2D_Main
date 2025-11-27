using System;
using System.Collections;
using UnityEngine;

namespace Turret
{
    public class TurretController : MonoBehaviour
    {
        private Animator turretAnim;
        [SerializeField] private ParticleSystem shootParticle;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPoint;

        private Transform turretHead;
        private Transform target;

        [SerializeField] private float angle = 60f;
        [SerializeField] private float rotSpeed = 0.5f;

        [SerializeField] private float shootCooldown = 1f;
        [SerializeField] private float bulletSpeed = 15f;

        private float theta;

        void Start()
        {
            turretAnim = GetComponent<Animator>();
            turretHead = transform.GetChild(0);

            StartCoroutine(ShootRoutine());
        }

        void Update()
        {
            Turn();
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
        
        private void Turn()
        {
            if (target != null) // Target이 있을 때 대상을 바라보는 기능
            {
                turretHead.LookAt(target);
            }
            else // Target이 없을 때 주변을 둘러보는 기능
            {
                theta += Time.deltaTime * rotSpeed;

                float rotationAngle = Mathf.Sin(theta) * angle;

                turretHead.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
            }
        }
        
        // 타겟이 있을 때까지 대기
        IEnumerator ShootRoutine()
        {
            while (true)
            {
                yield return new WaitUntil(() => target != null);
                
                GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();
                
                bulletRb.AddForce(shootPoint.forward * bulletSpeed, ForceMode.Impulse);
                
                turretAnim.SetTrigger("Shoot");
                shootParticle.Play();
                
                yield return new WaitForSeconds(shootCooldown);
            }
        }
    }
}