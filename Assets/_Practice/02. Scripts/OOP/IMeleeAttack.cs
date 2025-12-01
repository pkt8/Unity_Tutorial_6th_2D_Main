using UnityEngine;

public interface IMeleeAttack
{
    float MeleeDamage { get; set; }

    void MeleeAttack();
}