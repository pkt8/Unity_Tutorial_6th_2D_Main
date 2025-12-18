using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private GameObject[] popupUIs;
    
    private Stack<GameObject> uiStack = new Stack<GameObject>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int j = i;
            buttons[i].onClick.AddListener(() => PopupOn(j));
        }
        
        // buttons[0].onClick.AddListener(() => PopupOn(0));
        // buttons[1].onClick.AddListener(() => PopupOn(1));
        // buttons[2].onClick.AddListener(() => PopupOn(2));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject lastestUI = uiStack.Pop();
            lastestUI.SetActive(false);
        }
    }

    private void PopupOn(int index)
    {
        popupUIs[index].SetActive(true);
        uiStack.Push(popupUIs[index]); // 현재 킨 팝업을 Stack 추가
    }
}