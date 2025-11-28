using UnityEngine;

namespace StudyInterface
{
    public class Car : MonoBehaviour, IMove
    {
        public float MoveSpeed { get; set; }
        
        public void Move()
        {
            
        }
    }
}