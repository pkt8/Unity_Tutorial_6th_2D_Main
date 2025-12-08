using Platformer;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 houseInPos;
    [SerializeField] private Vector3 houseOutPos;
    
    public bool IsInteracting { get; private set; }

    public void Interact(Transform interactor = null)
    {
        if (!IsInteracting) // 현재 건물 밖에 있는 상태
        {
            IsInteracting = true;
            interactor.position = houseInPos;
        }
        else // 현재 건물 안에 있는 상태
        {
            IsInteracting = false;
            interactor.position = houseOutPos;
        }

        // // 삼항 연산자
        // IsInteracting = !IsInteracting; // 현재 상태를 반대로 설정
        // var pos = IsInteracting ? houseInPos : houseOutPos;
        //
        // interactor.position = pos;
    }

    public void UnInteract()
    {
        
    }
}