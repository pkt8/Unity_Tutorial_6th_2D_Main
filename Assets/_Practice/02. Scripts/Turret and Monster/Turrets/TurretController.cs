using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private Transform curretTarget;
        private List<Transform> targets = new List<Transform>();

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
                targets.Add(other.transform);

                if (targets.Count == 1) // 등록된 타겟이 1개밖에 없다면
                {
                    curretTarget = targets[0]; // 0번 대상을 타겟으로 설정
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Monster"))
            {
                if (targets.Contains(other.transform))
                {
                    targets.Remove(other.transform);
                    SetTarget();
                }
                
                if (targets.Count == 0) // 등록된 타겟이 없다면
                {
                    curretTarget = null; // 타겟을 null 설정
                }
            }
        }

        private void SetTarget()
        {
            if (targets.Count > 0)
            {
                curretTarget = targets[0];
            }
            else
            {
                curretTarget = null;
            }
        }
        
        private void Turn()
        {
            if (curretTarget != null) // Target이 있을 때 대상을 바라보는 기능
            {
                Vector3 targetPos = curretTarget.position + Vector3.up * 0.5f; // 타겟보다 살짝 높이 올려서 발사
                
                turretHead.LookAt(targetPos);

                // 마지막으로 LookAt한 상태에서 이어서 회전하는 기능
                float currentAngle = turretHead.localEulerAngles.y; // 0 ~ 360도 범위
                
                if (currentAngle > 180f)
                {
                    currentAngle -= 360f; // -180 ~ 180도 범위로 변경
                }
                
                float nomalizeAngle = Mathf.Clamp(currentAngle / angle, -1f, 1f);
                
                theta = Mathf.Asin(nomalizeAngle);
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
                yield return new WaitUntil(() => curretTarget != null);
                
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