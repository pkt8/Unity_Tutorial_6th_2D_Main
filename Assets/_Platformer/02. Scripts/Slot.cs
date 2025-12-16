using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class Slot : MonoBehaviour
    {
        private IItem item; // 슬롯에 들어올 아이템
        [SerializeField] private Button slotButton; // 먹은 아이템의 Use() 기능이 실행될 버튼
        [SerializeField] private Image slotImage; // 먹은 아이템의 이미지가 들어갈 UI
        
        public bool IsEmpty { get; private set; }

        void Awake()
        {
            IsEmpty = true;
            slotButton.onClick.AddListener(UseItem);
        }

        void OnEnable()
        {
            slotImage.gameObject.SetActive(!IsEmpty);
            slotButton.interactable = !IsEmpty;
            
            // if (!IsEmpty)
            // {
            //     slotImage.gameObject.SetActive(true);
            //     slotButton.interactable = true;
            // }
            // else
            // {
            //     slotImage.gameObject.SetActive(false);
            //     slotButton.interactable = false;
            // }
        }

        public void AddItem(IItem item)
        {
            this.item = item;
            IsEmpty = false;
            slotImage.sprite = item.Icon;
            slotImage.SetNativeSize();
        }
        
        private void UseItem()
        {
            if (item == null)
                return;

            item.Use();
            item = null;
            IsEmpty = true;
            slotImage.gameObject.SetActive(false);
            slotButton.interactable = false;
        }
    }
}