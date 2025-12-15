using UnityEngine;

namespace Platformer
{
    public class Potion : MonoBehaviour, IInteractable, IItem
    {
        public enum PotionType { Red, Blue }
        public PotionType type;
        
        public bool IsInteracting { get; }
        
        public void Interact(Transform interactor = null)
        {
            Debug.Log($"{type}을 획득하였습니다.");
            Destroy(gameObject);
        }

        public void UnInteract() { }
    }
}