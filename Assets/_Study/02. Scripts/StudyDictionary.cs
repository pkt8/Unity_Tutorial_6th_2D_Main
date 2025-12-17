using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersonData2
{
    public int age;
    public float height;
    public float weight;
    public DetailData detail;

    public PersonData2(int age, float height, float weight, DetailData detail)
    {
        this.age = age;
        this.height = height;
        this.weight = weight;
        this.detail = detail;
    }
}

[Serializable]
public class DetailData
{
    public int a;
    public int b;
    public int c;
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData2> persons = new Dictionary<string, PersonData2>();
    
    public Dictionary<string, string> ds =  new Dictionary<string, string>();

    void Start()
    {
        PersonData2 person1 = new PersonData2(10, 130f, 30f, new DetailData());
        
        persons.Add("철수", person1);
    }
}