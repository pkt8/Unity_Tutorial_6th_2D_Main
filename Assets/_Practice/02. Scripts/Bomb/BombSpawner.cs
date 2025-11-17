using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    
    private float timer;
    public float spawnTime = 3f;
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            timer = 0f;
            Vector3 randomPos = new Vector3(Random.Range(-25, 26), 10, Random.Range(-25, 26));
            
            Instantiate(bombPrefab, randomPos, Quaternion.identity); // 특정 위치에 생성하는 기능
        }
    }
}