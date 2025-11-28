using UnityEngine;

namespace OOP
{
    public class Monster : MonoBehaviour
    {
        public virtual void Attack()
        {
            Debug.Log("데미지 적용");
        }

        public virtual void Shout() // 선택적 재정의 가능
        {
            Debug.Log("몬스터 생성 소리");
        }
        
        // 고블린, 오크, 트롤, 가고일, 드래곤
    }
}