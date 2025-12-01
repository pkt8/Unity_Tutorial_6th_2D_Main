using UnityEngine;

public class Horse : MonoBehaviour, IMove
{
    [field: SerializeField]
    public float MoveSpeed { get; set; }

    public bool IsRide { get; set; }

    void Start()
    {
        MoveSpeed = 7f;
    }
    
    void Update()
    {
        if (!IsRide)
            return;
        
        Move();
    }
    
    public void Move()
    {
        Debug.Log("말 움직임");
    }
}