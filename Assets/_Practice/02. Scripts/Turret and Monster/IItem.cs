using UnityEngine;

namespace Turret
{
    public interface IItem
    {
        GameObject Obj { get; set; }
        string Name { get; set; }
        int Price { get; set; }

        void Get();

        void Use();
    }
}