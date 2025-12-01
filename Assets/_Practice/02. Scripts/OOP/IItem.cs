using UnityEngine;

namespace OOP
{
    public interface IItem
    {
        Transform itemTransform { get; set; }
        
        void Grab();
        void Use();
        void Release();

        // void Reload();
    }
}
