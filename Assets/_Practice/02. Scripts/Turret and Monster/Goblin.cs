using UnityEngine;

namespace Turret
{
    public class Goblin : Monster
    {
        protected override void Init()
        {
            base.Init();

            hp = 3;
            moveSpeed = 2;
        }
    }
}