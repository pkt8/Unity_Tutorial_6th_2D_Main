using StudyInterface;
using UnityEngine;

public class HandGun : MonoBehaviour, IItem
{
    public void Grab() // 처음 아이템을 획득했을 때 실행되는 이벤트
    {
        // 총 장전하는 소리
    }

    public void Use() // 장착하고 마우스를 클릭했을 떄 실행되는 이벤트
    {
        // 총알 생성 및 발사
        // 총 발사 소리
    }

    public void Release() // 아이템을 버릴 때 실행되는 이벤트
    {
        // 툭 떨어지는 소리
    }
}