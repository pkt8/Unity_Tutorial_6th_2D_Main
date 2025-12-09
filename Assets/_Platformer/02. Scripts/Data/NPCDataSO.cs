using UnityEngine;

[CreateAssetMenu(fileName = "NPCDataSO", menuName = "Scriptable Objects/NPCDataSO")]
public class NPCDataSO : ScriptableObject
{
    public string name;
    public string age;
    public string gender;
    public string job;
    public string description;
    public Sprite icon;
}