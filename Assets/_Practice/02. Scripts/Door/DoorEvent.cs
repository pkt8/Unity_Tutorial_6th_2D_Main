using TMPro;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator doorAnim;
    public GameObject doorLockUI;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // 캐릭터가 문 앞에 다가오면 문이 열리는 기능
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLockUI.SetActive(true);
        }
    }

    // 캐릭터가 문 앞에서 멀어지면 문이 닫히는 기능
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLockUI.SetActive(false);
        }
    }

    public void SetDoorAnimation(bool isOpen)
    {
        if (isOpen)
            doorAnim.SetTrigger("Open");
        else
            doorAnim.SetTrigger("Close");
    }
}