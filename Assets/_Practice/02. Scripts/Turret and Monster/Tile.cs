using Turret;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private BoardManager board;

    void Start()
    {
        board = FindFirstObjectByType<BoardManager>();
    }
    
    void OnMouseDown()
    {
        Debug.Log(gameObject.name);

        board.CreateTurret(transform);
    }
}