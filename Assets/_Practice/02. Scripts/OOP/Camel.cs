using UnityEngine;

public class Camel : MonoBehaviour, IMove
{
    [field: SerializeField]
    public float MoveSpeed { get; set; }

    public bool IsRide { get; set; }

    void Start()
    {
        MoveSpeed = 5f;
    }
    
    void Update()
    {
        if (!IsRide)
            return;
        Move();
    }
    
    public void Move()
    {
        Debug.Log("낙타 움직임");
    }
}