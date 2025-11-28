using UnityEngine;

public interface IMove
{
    float MoveSpeed { get; set; }
    
    void Move();
}