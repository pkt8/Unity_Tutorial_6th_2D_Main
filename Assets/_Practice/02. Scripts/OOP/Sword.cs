using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}