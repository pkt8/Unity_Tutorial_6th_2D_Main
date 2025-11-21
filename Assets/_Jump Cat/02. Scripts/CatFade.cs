using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CatFade : MonoBehaviour
{
    public Image fadeUI;

    public GameObject playObj;
    public GameObject outroUI;

    public GameObject canvasObj;
    public GameObject videoObj;

    void Start()
    {
        fadeUI.gameObject.SetActive(false);
    }
    
    public void Fade(float fadeTime, Color fadeColor, bool isCompleted)
    {
        StartCoroutine(FadeRoutine(fadeTime, fadeColor, isCompleted));
    }

    IEnumerator FadeRoutine(float fadeTime, Color fadeColor, bool isCompleted)
    {
        fadeUI.gameObject.SetActive(true);
        
        float timer = 0f;
        float percent = 0f;
        Color newColor = fadeColor;
        
        while (true)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // 퍼센트값 연산

            newColor.a = Mathf.Lerp(0f, 1f, percent); // 이미지의 알파값 수정
            fadeUI.color = newColor; // 수정된 알파값을 적용

            if (percent >= 1f)
            {
                if (!isCompleted)
                {
                    playObj.SetActive(false);
                    outroUI.SetActive(true);
                }
                else
                {
                    canvasObj.SetActive(false);
                    videoObj.SetActive(true);
                }
                yield break;
            }
            yield return null;
        }
    }
}