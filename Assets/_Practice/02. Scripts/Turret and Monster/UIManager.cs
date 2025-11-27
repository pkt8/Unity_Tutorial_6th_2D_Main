using UnityEngine;

namespace Turret
{
    public class UIManager : MonoBehaviour
    {
        private BoardManager board;

        [SerializeField] private GameObject mainUI;
        [SerializeField] private GameObject selectUI;

        void Start()
        {
            board = FindFirstObjectByType<BoardManager>();
        }

        public void SelectUIOn()
        {
            mainUI.SetActive(false);
            selectUI.SetActive(true);
        }

        public void SetTurret(int index)
        {
            board.SetCurrentTurret(index);
            
            mainUI.SetActive(true);
            selectUI.SetActive(false);
        }
    }
}