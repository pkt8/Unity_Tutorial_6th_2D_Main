using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private AdventurerMovement movement;
    private AdventurerAttack attack;
    
    [SerializeField] private TMP_Dropdown selectedInput;
    
    [SerializeField] private GameObject optionUI;

    [SerializeField] private Button optionButton;
    [SerializeField] private Button optionExitButton;

    void Start()
    {
        movement = FindFirstObjectByType<AdventurerMovement>();
        attack = FindFirstObjectByType<AdventurerAttack>();

        selectedInput.onValueChanged.AddListener(SetInputType);
        
        optionButton.onClick.AddListener(OptionUIOn);
        optionExitButton.onClick.AddListener(OptionUIOff);

        // 입력 타입은 Movement 기준
        attack.inputType = movement.inputType; // Movement Type을 Attack에 적용
        
        selectedInput.value = (int)movement.inputType; // Dropdown에 Movement Type 적용
    }
    
    private void OptionUIOn()
    {
        Time.timeScale = 0f;
        optionUI.SetActive(true);
    }
    
    private void OptionUIOff()
    {
        Time.timeScale = 1f;
        optionUI.SetActive(false);
    }

    // private void ActiveOptionUI()
    // {
    //     bool isActive = optionUI.activeSelf;
    //     
    //     optionUI.SetActive(!isActive);
    // }
    
    private void SetInputType(int index)
    {
        if (index == 0) // Keyboard 설정
        {
            movement.inputType = InputType.Keyboard;
            attack.inputType = InputType.Keyboard;
        }
        else if (index == 1) // Joystick 설정
        {
            movement.inputType = InputType.Joystick;
            attack.inputType = InputType.Joystick;
        }
    }
}