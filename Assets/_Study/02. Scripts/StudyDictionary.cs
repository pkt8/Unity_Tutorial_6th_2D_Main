using System;
using System.Collections.Generic;
using UnityEngine;

// [Serializable]
// public class PersonData2
// {
//     public int age;
//     public float height;
//     public float weight;
//     public DetailData detail;
//
//     public PersonData2(int age, float height, float weight, DetailData detail)
//     {
//         this.age = age;
//         this.height = height;
//         this.weight = weight;
//         this.detail = detail;
//     }
// }
//
// [Serializable]
// public class DetailData
// {
//     public int a;
//     public int b;
//     public int c;
// }

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();
    
    void Start()
    {
        persons.Add("철수", 1);

        persons["철수"] = 10; // 값 변경
        
        persons.Add("철수", 2); // 이미 있는 Key이기 때문에 에러 발생
    }
}