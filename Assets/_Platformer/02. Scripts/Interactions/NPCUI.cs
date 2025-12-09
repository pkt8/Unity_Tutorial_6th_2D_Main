using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;
    [SerializeField] private TextMeshProUGUI ageUI;
    [SerializeField] private TextMeshProUGUI genderUI;
    [SerializeField] private TextMeshProUGUI jobUI;
    [SerializeField] private TextMeshProUGUI descriptionUI;
    [SerializeField] private Image iconUI;
    
    public void SetData(string name, string age, string gender, string job, string description, Sprite icon)
    {
        nameUI.text = name;
        ageUI.text = age;
        genderUI.text = gender;
        jobUI.text = job;
        descriptionUI.text = description;
        iconUI.sprite = icon;
    }
}