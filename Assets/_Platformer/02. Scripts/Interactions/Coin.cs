using UnityEngine;

namespace Platformer
{
    public class Coin : MonoBehaviour, IInteractable, IItem
    {
        public enum CoinType { Red, Green, Blue, Purple, Gold }
        public CoinType type;
        
        public bool IsInteracting { get; }
        
        public void Interact(Transform interactor = null)
        {
            Debug.Log($"{type}을 획득하였습니다.");
            Destroy(gameObject);
        }

        public void UnInteract() { }
    }
}