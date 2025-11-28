using System;
using StudyInterface;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    public IItem currentItem;
    
    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if (item != null)
        {
            item.Grab(); // 장착하는 기능
            currentItem = item;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 사용하는 기능
        {
            currentItem.Use();
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 버리는 기능
        {
            currentItem.Release();
        }
    }
}