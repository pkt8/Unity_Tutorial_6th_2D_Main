using UnityEngine;

public interface IMove
{
    float MoveSpeed { get; set; } // 자동구현 프로퍼티
    bool IsRide { get; set; }

    void Move();
}