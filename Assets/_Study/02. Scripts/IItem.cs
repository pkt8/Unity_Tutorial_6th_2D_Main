using UnityEngine;

namespace StudyInterface
{
    public interface IItem
    {
        void Grab();
        void Use();
        void Release();
    }
}