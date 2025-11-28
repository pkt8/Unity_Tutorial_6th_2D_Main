using System.Collections;
using UnityEngine;

namespace Turret
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] monsterPrefabs;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnTime = 3f;

        IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                
                int randomIndex = Random.Range(0, monsterPrefabs.Length);
                Instantiate(monsterPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}