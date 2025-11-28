using UnityEngine;

namespace Turret
{
    public class HobGoblin : Monster
    {
        protected override void Init()
        {
            base.Init();
            
            hp = 5;
            moveSpeed = 1.5f;
        }
    }
}