using Turret;
using UnityEngine;

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
        if (!isCreate) // 중복 생성 방지
        {
            isCreate = true;
            board.CreateTurret(transform);
        }
    }
}