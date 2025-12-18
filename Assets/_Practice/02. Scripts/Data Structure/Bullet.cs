using UnityEngine;

namespace DataStructure
{
    public class Bullet : MonoBehaviour
    {
        private PlayerFire playerFire;
        
        public float speed = 10f;

        void Awake()
        {
            playerFire = FindFirstObjectByType<PlayerFire>();
        }
        
        void OnEnable()
        {
            Invoke("ReturnPool", 3f);
        }

        void Update()
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        private void ReturnPool()
        {
            playerFire.bulletPool.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}