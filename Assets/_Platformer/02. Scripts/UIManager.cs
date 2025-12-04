using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject optionUI;

    [SerializeField] private Button optionButton;
    [SerializeField] private Button optionExitButton;

    void Start()
    {
        optionButton.onClick.AddListener(OptionUIOn);
        optionExitButton.onClick.AddListener(OptionUIOff);
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
}