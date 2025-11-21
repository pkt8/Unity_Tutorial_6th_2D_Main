using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StudyCoroutine : MonoBehaviour
{
    public Image fadeUI;

    private bool isFade;

    public void OnFade(float fadeTime, float waitTime, Color targetColor)
    {
        StartCoroutine(FadeRoutine(fadeTime, waitTime, targetColor));
    }

    IEnumerator FadeRoutine(float fadeTime, float waitTime, Color targetColor)
    {
        Color newColor = targetColor;

        isFade = false;
        float timer = 0f;
        float percent = 0f;

        while (true)
        {
            if (!isFade) // Fade In 기능 실행
            {
                timer += Time.deltaTime;
                percent = timer / fadeTime;

                newColor.a = Mathf.Lerp(0f, 1f, percent);
                fadeUI.color = newColor;

                if (percent >= 1f)
                {
                    isFade = true;
                    timer = 0f;
                    percent = 0f;

                    yield return new WaitForSeconds(waitTime);
                }
            }
            else // Fade Out 기능 실행
            {
                timer += Time.deltaTime;
                percent = timer / fadeTime;

                newColor.a = Mathf.Lerp(1f, 0f, percent);
                fadeUI.color = newColor;

                if (percent >= 1f)
                {
                    Debug.Log("페이드 완료");
                    yield break;
                }
            }

            yield return null;
        }
    }
}