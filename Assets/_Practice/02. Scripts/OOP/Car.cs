using UnityEngine;

public class Car : MonoBehaviour, IMove, IDamageable
{
    [field: SerializeField]
    public float MoveSpeed { get; set; }
    
    public int Hp { get; set; }

    public bool IsRide { get; set; }

    void Start()
    {
        MoveSpeed = 10f;
        Hp = 10;
    }

    void Update()
    {
        if (!IsRide)
            return;
        
        Move();
    }
    
    public void Move()
    {
        Debug.Log("자동차 움직임");

        float v = Input.GetAxis("Vertical");

        Vector3 dir = new(0, 0, v);
        transform.position += dir * MoveSpeed * Time.deltaTime;
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
        Debug.Log("자동차 파괴");
    }
}