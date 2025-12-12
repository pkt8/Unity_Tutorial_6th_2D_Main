using System;
using Platformer;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private AdventurerMovement movement;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (movement == null)
            movement = other.gameObject.GetComponent<AdventurerMovement>();
        
        movement.SetGroundAnimation(true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        movement.SetGroundAnimation(false);
    }
}