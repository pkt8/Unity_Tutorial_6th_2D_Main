using StudyInterface;
using UnityEngine;

public class FlashLight : MonoBehaviour, IItem
{
    private bool isFlashOn;
    
    public void Grab()
    {
        // 손전등 든 소리
    }

    public void Use()
    {
        // 손전등 키거나 끄는 기능
        isFlashOn = !isFlashOn;
    }

    public void Release()
    {
        // 손전등 버리는 소리
    }
}