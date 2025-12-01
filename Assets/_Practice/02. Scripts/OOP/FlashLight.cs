using OOP;
using UnityEngine;

public class FlashLight : MonoBehaviour, IItem
{
    public GameObject lightObj;

    public Transform itemTransform { get; set; }

    void Start()
    {
        itemTransform = transform;
    }
    
    public void Grab()
    {
        Debug.Log("손전등 장착");
    }

    public void Use()
    {
        bool isActive = lightObj.activeSelf; // 현재 오브젝트 Active 상태
        
        lightObj.SetActive(!isActive); // 현재 상태를 반대로 적용
    }

    public void Release()
    {
        Debug.Log("손전등 버림");
    }

    // public void Reload() { }
}