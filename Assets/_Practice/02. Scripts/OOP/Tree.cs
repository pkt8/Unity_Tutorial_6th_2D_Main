using UnityEngine;

public class Tree : MonoBehaviour, IDamageable
{
    public int Hp { get; set; }

    void Start()
    {
        Hp = 5;
    }
    
    public void TakeDamage(int dmg)
    {
        Debug.Log($"{name}이 {dmg}만큼의 피해를 입었습니다.");
        
        Hp -= dmg;
        if (Hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("나무 파괴");
    }
}