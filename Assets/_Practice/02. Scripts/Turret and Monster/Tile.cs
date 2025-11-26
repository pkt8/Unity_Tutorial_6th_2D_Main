using Turret;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private BoardManager board;

    private bool isCreate = false; // 처음에 생성되어있지 않은 상태

    void Start()
    {
        board = FindFirstObjectByType<BoardManager>();
    }
    
    void OnMouseDown() // 오브젝트를 클릭했을 때 이벤트 함수
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!isCreate) // 중복 생성 방지
        {
            isCreate = true;
            board.CreateTurret(transform);
            
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnMouseOver() // 마우스가 오브젝트에 올려진 경우 발생하는 이벤트 함수
    {
        // 터렛이 이미 생성된 타일의 경우 -> 미리보기 보이면 X

        if (!isCreate)
        {
            board.SetPreviewTurret(transform.position);
        }
    }
}