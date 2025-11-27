using UnityEngine;

namespace Turret
{
    public class Goblin : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] private float moveSpeed = 0.05f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            rb.linearVelocity = Vector3.right * moveSpeed;
        }
    }
}