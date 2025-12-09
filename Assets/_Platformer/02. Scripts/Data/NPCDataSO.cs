using UnityEngine;

[CreateAssetMenu(fileName = "NPCDataSO", menuName = "Scriptable Objects/NPCDataSO")]
public class NPCDataSO : ScriptableObject
{
    public string name;
    public string age;
    public string gender;
    public string job;
    public string description;
    public Sprite icon; // 과일상인 - 0.75 / 대장장이 - 1
}