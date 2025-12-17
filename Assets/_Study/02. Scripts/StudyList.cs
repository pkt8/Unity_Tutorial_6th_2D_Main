using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public string name;
    public int age;
    public float height;

    public PersonData(string name, int age, float height)
    {
        this.name = name;
        this.age = age;
        this.height = height;
    }
}

public class StudyList : MonoBehaviour
{
    public List<PersonData> persons = new List<PersonData>();

    void Start()
    {
        var person1 = new PersonData("철수", 10, 130f);
        persons.Add(person1);
        
        var person2 = new PersonData("영희", 9, 100f);
        persons.Add(person2);
    }
}