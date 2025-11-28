using System.Collections.Generic;
using StudyInterface;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public List<IMove> movers = new List<IMove>();
    
    void Start()
    {
        Orc2 orc = new Orc2();
        Car car = new Car();

        movers.Add(orc);
        movers.Add(car);
        
        foreach (var mover in movers)
        {
            mover.Move();
        }
    }
}