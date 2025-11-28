using UnityEngine;

namespace Turret
{
    public class Goblin : Monster
    {
        void Start()
        {
            Init(3, 2);
        }
        
        // protected override void Init(float hp, float moveSpeed)
        // {
        //     base.Init(hp, moveSpeed);
        //     
        //     // 기능 추가
        // }
    }
}