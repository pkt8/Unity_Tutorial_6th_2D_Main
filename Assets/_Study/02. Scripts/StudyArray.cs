using System.Collections.Generic;
using UnityEngine;

// 정적 배열 (Static Array) -> 배열
public class StudyArray : MonoBehaviour
{
    #region 정적배열(Static Array)

    public int[] array1; // 변수 선언
    public int[] array2 = { 1, 2, 3, 4, 5 }; // 변수 선언 및 5개의 값 할당
    public int[] array3 = new int[5]; // 변수 선언 및 5칸 할당 (기본값 0 적용)
    public int[] array4 = new int[5] { 1, 2, 3, 4, 5 }; // 변수 선언 및 5칸과 5개 값 할당

    #endregion

    #region 다차원배열(MultiDimensionalArray)

    public int[,] array5 = new int[3, 3]; // 3행 3열의 2차원 배열
    public int[,,] array6 = new int[3, 3, 3]; // 3차원 배열

    #endregion

    #region 다중배열(JaggedArray)

    public int[][] array7 = new int[3][];

    #endregion

    #region 동적배열(DynamicArray)

    public List<int> list1 = new List<int>(); // 리스트 선언
    public List<int> list2 = new List<int>(5); // 리스트 선언 및 공간 설정
    public List<int> list3 = new List<int>() { 1, 2, 3, 4, 5 }; // 리스트 선언 및 값 할당

    #endregion

    void Start()
    {
        list1.Add(1); // 1 추가
        list1.Add(2); // 2 추가

        for (int i = 0; i < 10; i++) // 0 ~ 9까지 값 추가
            list1.Add(i);

        list1.Insert(2, 100); // 인덱스 2번 위치에 100 추가

        list1.Remove(2); // 첫번째로 찾은 값 2만 삭제

        list1.RemoveAt(2); // 인덱스 2번 위치 값 삭제

        list1.RemoveRange(2, 5); // 인덱스 2번부터 5개 데이터 삭제

        list1.RemoveAll(n => n > 5); // 조건에 만족하는 대상만 지우기
        
        list1.Clear(); // 완전히 지우기
    }
}