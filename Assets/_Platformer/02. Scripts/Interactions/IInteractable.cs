namespace Platformer
{
    public interface IInteractable
    {
        bool IsInteracting { get; }

        void Interact();
        void UnInteract();
    }
}