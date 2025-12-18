using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRect;

    private Vector2 basePos;
    private Vector2 startPos;
    private Vector2 moveOffset;

    private Vector2 minAnchor, maxAnchor, anchorPos, deltaSize;

    private float timer;
    private float doubleClickTime = 0.15f;

    private bool isDoubleClicked = false;
    private bool isFullScreen = false;

    void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isDoubleClicked) // 더블 클릭 체크
        {
            timer += Time.deltaTime;
            if (timer >= doubleClickTime)
            {
                timer = 0f;
                isDoubleClicked = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isDoubleClicked) // 첫 클릭
            isDoubleClicked = true;
        else // doubleClickTime 시간 안에 클릭
            SetFullScreen();

        if (isFullScreen)
            return;

        parentRect.SetAsLastSibling(); // 계층구조상 가장 아래로 옮기기
        
        basePos = parentRect.anchoredPosition;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFullScreen)
            return;
        
        moveOffset = eventData.position - startPos;
        parentRect.anchoredPosition = basePos + moveOffset;
    }

    private void SetFullScreen()
    {
        if (!isFullScreen)
        {
            isFullScreen = true;

            // 기존 값 저장
            minAnchor = parentRect.anchorMin;
            maxAnchor = parentRect.anchorMax;
            anchorPos = parentRect.anchoredPosition;
            deltaSize = parentRect.sizeDelta;

            // 풀사이즈로 변경
            parentRect.anchorMin = Vector2.zero;
            parentRect.anchorMax = Vector2.one;
            parentRect.anchoredPosition = Vector2.zero;
            parentRect.sizeDelta = Vector2.zero;
        }
        else
        {
            isFullScreen = false;

            parentRect.anchorMin = minAnchor;
            parentRect.anchorMax = maxAnchor;
            parentRect.anchoredPosition = anchorPos;
            parentRect.sizeDelta = deltaSize;
        }
    }
}