using UnityEngine;

namespace Turret
{
    public class BoardManager : MonoBehaviour
    {
        public GameObject whiteTilePrefab;
        public GameObject blackTilePrefab;
        public GameObject currentTurret;
        public GameObject[] turrets;

        public Vector3 boardSize = new Vector3(10, 0, 5);

        void Start()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            // 2중 반복문
            for (int i = 0; i < boardSize.x; i++)
            {
                for (int j = 0; j < boardSize.z; j++)
                {
                    // 타일 생성
                    GameObject tileObj;

                    if ((i + j) % 2 == 0) // 두 값을 더했을 때 짝수
                    {
                        tileObj = Instantiate(whiteTilePrefab, transform);
                    }
                    else // 두 값을 더했을 때 홀수
                    {
                        tileObj = Instantiate(blackTilePrefab, transform);
                    }

                    tileObj.name = $"Tile_{i}_{j}";
                    tileObj.transform.position = new Vector3(i, 0, j);
                }
            }
        }

        public void CreateTurret(Transform parent)
        {
            if (currentTurret == null)
                return;
            
            GameObject turretObj = Instantiate(currentTurret);
            
            turretObj.transform.SetParent(parent);
            turretObj.transform.localPosition = Vector3.zero;
            
            currentTurret = null; // 터렛 추가 생성 방지
        }

        public void SetCurrentTurret(int index)
        {
            currentTurret = turrets[index];
        }
    }
}