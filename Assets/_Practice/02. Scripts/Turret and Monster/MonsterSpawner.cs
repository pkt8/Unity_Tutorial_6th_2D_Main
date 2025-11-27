using System.Collections;
using UnityEngine;

namespace Turret
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject monsterPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnTime = 3f;

        IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);

                Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}