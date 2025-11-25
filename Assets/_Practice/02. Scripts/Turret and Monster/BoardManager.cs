using UnityEngine;

namespace Turret
{
    public class BoardManager : MonoBehaviour
    {
        public GameObject whiteTilePrefab;
        public GameObject blackTilePrefab;
        public GameObject turretPrefab;

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
            GameObject turretObj = Instantiate(turretPrefab);
            
            turretObj.transform.SetParent(parent);
            turretObj.transform.localPosition = Vector3.zero;
        }
    }
}