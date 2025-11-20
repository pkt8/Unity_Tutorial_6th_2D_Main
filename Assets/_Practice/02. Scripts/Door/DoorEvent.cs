using TMPro;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator doorAnim;
    public GameObject doorLockUI;

    public bool isDoorOpen = false;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLockUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLockUI.SetActive(false);

            if (isDoorOpen)
                SetDoorAnimation(false);
        }
    }

    public void SetDoorAnimation(bool isOpen)
    {
        isDoorOpen = isOpen;
        
        if (isOpen)
            doorAnim.SetTrigger("Open");
        else
            doorAnim.SetTrigger("Close");
        
        // 변수타입 변수명 = 조건 ? 참일 때 : 거짓일 때
        // string triggerName = isOpen ? "Open" : "Close";
        // doorAnim.SetTrigger(triggerName);
    }
}