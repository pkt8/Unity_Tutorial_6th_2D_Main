using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    public CharacterMovement2D movement;
    private Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // 캐릭터가 문 앞에 다가오면 문이 열리는 기능
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("Open");
        }
    }

    // 캐릭터가 문 앞에서 멀어지면 문이 닫히는 기능
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("Close");
        }
    }
}