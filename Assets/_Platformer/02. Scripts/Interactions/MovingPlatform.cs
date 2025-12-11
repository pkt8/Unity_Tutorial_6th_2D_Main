using Platformer;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IInteractable
{
    public enum MoveType { Horizontal, Vertical }
    public MoveType moveType;
    
    [SerializeField] private float moveSpeed;
    private float theta;
    
    public bool IsInteracting { get; }
    
    public void Interact(Transform interactor = null)
    {
        
    }

    public void UnInteract()
    {
        
    }
}