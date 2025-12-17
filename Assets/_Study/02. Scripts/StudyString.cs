using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World***";
    
    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    public string[] fruits;

    void Start()
    {
        // Debug.Log(str1[0]); // H
        // Debug.Log(str1[2]); // l
        // Debug.Log(str1[5]); //  
        //
        // Debug.Log(str2[0]); // Hello
        // Debug.Log(str2[2]); // World
        //
        // int[] numbers1 = new int[5];
        // Debug.Log(numbers1.Length); // 배열의 길이 : 5
        //
        // List<int> numbers2 = new List<int>(7);
        // Debug.Log(numbers2.Count); // 리스트의 개수 : 7
        //
        // Debug.Log(str1.Length); // 14
        //
        // Debug.Log(str1.Trim()); // 앞뒤 공백 제거
        // Debug.Log(str1.Trim('*')); // 앞뒤 * 제거
        // Debug.Log(str1.Trim(',')); // 앞뒤 , 제거
        //
        // Debug.Log(str1.Contains('H')); // 대문자 H가 있는지?
        // Debug.Log(str1.Contains("Hello")); // Hello가 있는지?
        //
        // Debug.Log(str1.ToUpper()); // 대문자 변환
        // Debug.Log(str1.ToLower()); // 소문자 변환
        //
        // str1 = "Hello World";
        // string newStr = str1.Replace("Hello", "Unity"); // "Hello"를 "Unity" 교체 -> "Unity World"

        string str3 = "Apple,Banana,Orange,Melon,Water Melon, Mange"; // csv 타입의 문자열
        
        fruits = str3.Split(',');
    }
}