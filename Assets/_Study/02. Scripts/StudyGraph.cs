using System.Collections.Generic;
using UnityEngine;

public class GraphNode<T>
{
    public T data;
    public List<GraphNode<T>> neighbors = new List<GraphNode<T>>();

    public GraphNode(T data)
    {
        this.data = data;
        this.neighbors = new List<GraphNode<T>>();
    }
}

public class StudyGraph : MonoBehaviour
{
    public GraphNode<int>[] nodes = new GraphNode<int>[7];

    public int nodeNumber;

    void Start()
    {
        // 노드 생성
        for (int i = 0; i < nodes.Length; i++)
            nodes[i] = new GraphNode<int>(i);

        // 노드 연결
        nodes[0].neighbors.Add(nodes[1]);
        nodes[0].neighbors.Add(nodes[3]);
        
        nodes[1].neighbors.Add(nodes[0]);
        nodes[1].neighbors.Add(nodes[2]);
        nodes[1].neighbors.Add(nodes[3]);
        
        nodes[2].neighbors.Add(nodes[1]);
        nodes[2].neighbors.Add(nodes[3]);
        
        nodes[3].neighbors.Add(nodes[0]);
        nodes[3].neighbors.Add(nodes[1]);
        nodes[3].neighbors.Add(nodes[2]);
        nodes[3].neighbors.Add(nodes[4]);
        nodes[3].neighbors.Add(nodes[5]);
        
        nodes[4].neighbors.Add(nodes[3]);
        nodes[4].neighbors.Add(nodes[5]);
        
        nodes[5].neighbors.Add(nodes[3]);
        nodes[5].neighbors.Add(nodes[4]);
        nodes[5].neighbors.Add(nodes[6]);
        
        nodes[6].neighbors.Add(nodes[5]);
        
        // 연결된 노드 수 확인
        Debug.Log($"노드 {nodeNumber}의 이웃 노드의 수 : {nodes[nodeNumber].neighbors.Count}");
        
        // 연결된 노드 확인
        foreach (var graphNode in nodes[nodeNumber].neighbors)
        {
            Debug.Log(graphNode.data);
        }
    }
}