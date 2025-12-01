using UnityEngine;

public interface IDamageable
{
    int Hp { get; set; }
    
    void TakeDamage(int dmg);
    void Death();
}