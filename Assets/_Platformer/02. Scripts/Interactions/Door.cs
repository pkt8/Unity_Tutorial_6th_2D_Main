using Platformer;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool IsInteracting { get; private set; }

    public void Interact()
    {
        IsInteracting = true;

        Debug.Log("집 안으로 이동");
    }

    public void UnInteract()
    {
        IsInteracting = false;

        Debug.Log("집 밖으로 이동");
    }
}