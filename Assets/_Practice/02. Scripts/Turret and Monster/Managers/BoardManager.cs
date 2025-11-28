using UnityEngine;

namespace Turret
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private GameObject whiteTilePrefab;
        [SerializeField] private GameObject blackTilePrefab;

        public GameObject CurrentTurret { get; private set; }
        
        [SerializeField] private GameObject[] turrets;
        
        [SerializeField] private GameObject[] prevTurrets;

        private int turretIndex;

        [SerializeField] private Vector3 boardSize = new Vector3(10, 0, 5);

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
            if (CurrentTurret == null)
                return;

            GameObject turretObj = Instantiate(CurrentTurret);

            turretObj.transform.SetParent(parent);
            turretObj.transform.localPosition = Vector3.zero;

            CurrentTurret = null; // 터렛 추가 생성 방지
            prevTurrets[turretIndex].SetActive(false); // 미리보기 터렛 끄는 기능
        }

        public void SetCurrentTurret(int index) // 터렛 선택
        {
            turretIndex = index;
            CurrentTurret = turrets[turretIndex];

            // 기존에 선택한 Prev 터렛 초기화
            foreach (GameObject turret in prevTurrets)
            {
                turret.SetActive(false);
            }
        }

        public void SetPreviewTurret(Vector3 tilePos)
        {
            // 터렛을 선택하지 않았을 때 Prev 터렛이 뜨는 문제 방지
            if (CurrentTurret == null)
                return;

            prevTurrets[turretIndex].SetActive(true);

            prevTurrets[turretIndex].transform.position = tilePos;
        }
    }
}