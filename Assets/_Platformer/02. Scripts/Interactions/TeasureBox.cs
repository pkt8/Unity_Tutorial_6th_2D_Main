using System.Collections;
using Platformer;
using UnityEngine;

public class TeasureBox : MonoBehaviour, IInteractable
{
    private Animator anim;

    public bool IsInteracting { get; private set; }
    private bool isOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Interact(Transform interactor = null)
    {
        IsInteracting = true;
        StartCoroutine(InteractRoutine());
    }

    IEnumerator InteractRoutine()
    {
        while (IsInteracting && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOpen = true;
                anim.SetTrigger("Open");
                Debug.Log("상자를 열었습니다.");
                break;
            }
            
            yield return null;
        }
    }

    public void UnInteract()
    {
        IsInteracting = false;
    }
}