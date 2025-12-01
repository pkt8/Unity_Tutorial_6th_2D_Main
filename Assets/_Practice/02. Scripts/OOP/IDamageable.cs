using Turret;
using UnityEngine;

public interface IDamageable
{
    void GetDamage(float damage, TurretController turret);

    void Death();
}