using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;

    public int poolSize = 5;
    public Queue<GameObject> bulletPool = new Queue<GameObject>();

    void Start()
    {
        CreateBullet();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletPool.Count > 0)
            {
                GameObject bullet = bulletPool.Dequeue(); // 큐에서 데이터 꺼내기
                bullet.transform.position = firePoint.transform.position; // 발사 위치로 이동

                bullet.SetActive(true); // 총알 활성화
            }
            else
                CreateBullet();
        }
    }

    private void CreateBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bulletObj = Instantiate(bulletPrefab);
            bulletPool.Enqueue(bulletObj);

            bulletObj.SetActive(false);
        }
    }
}