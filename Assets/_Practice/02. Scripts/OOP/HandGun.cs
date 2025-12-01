using OOP;
using UnityEngine;

public class HandGun : MonoBehaviour, IItem
{
    public AudioSource audioSource;
    public AudioClip shootClip;

    public Transform itemTransform { get; set; }

    void Start()
    {
        itemTransform = transform;
    }
    
    public void Grab()
    {
        Debug.Log("권총 장착");
    }

    public void Use()
    {
        audioSource.PlayOneShot(shootClip);
    }

    public void Release()
    {
        Debug.Log("권총 버림");
    }

    // public void Reload()
    // {
    //     // 총알 장전
    // }
}