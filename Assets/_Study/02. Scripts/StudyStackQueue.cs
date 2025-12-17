using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyStackQueue : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public Queue<int> queue = new Queue<int>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            stack.Push(i);
            queue.Enqueue(i);
        }
        
        // int[] array = { 1, 2, 3 };
        //
        // stack = new Stack<int>(array); // Array -> Stack
        // queue = new Queue<int>(array); // Array -> Queue
        //
        // Debug.Log($"Stack에서 나올 값 : {stack.Peek()}");
        // Debug.Log($"Queue에서 나올 값 : {queue.Peek()}");

        int[] array1 = stack.ToArray(); // Stack -> Array
        int[] array2 = queue.ToArray(); // Queue -> Array
    }
}