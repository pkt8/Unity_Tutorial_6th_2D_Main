using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Routine");
    }

    IEnumerator Routine()
    {
        yield return null; // 1 프레임 대기
        Debug.Log("1초");
        
        yield return new WaitForSeconds(1f);
        Debug.Log("2초");
        
        yield return new WaitForSeconds(1f);
        Debug.Log("3초");
    }
}