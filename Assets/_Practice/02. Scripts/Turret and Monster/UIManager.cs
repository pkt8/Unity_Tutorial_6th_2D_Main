using UnityEngine;

namespace Turret
{
    public class UIManager : MonoBehaviour
    {
        private BoardManager board;

        public GameObject mainUI;
        public GameObject selectUI;

        void Start()
        {
            board = FindFirstObjectByType<BoardManager>();
        }

        public void SelectUIOn()
        {
            // main UI Off
            // select UI On

            mainUI.SetActive(false);
            selectUI.SetActive(true);
        }

        public void SetTurret(int index)
        {
            // BoardManager에 있는 Current Turret을 변경
            
            board.SetCurrentTurret(index);
            
            mainUI.SetActive(true);
            selectUI.SetActive(false);
        }
    }
}