using System;
using TMPro;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public DoorEvent door;
    public TextMeshProUGUI passwordText;

    public string password;
    public string currPassword;

    void OnDisable()
    {
        currPassword = String.Empty;
        passwordText.text = $"입력한 번호 : {currPassword}";
    }

    public void OnKeypadNumber(string number)
    {
        currPassword += number;
        passwordText.text = $"입력한 번호 : {currPassword}";

        // passwordText.text = "입력한 번호 : " + currPassword;
        // passwordText.text = string.Format("입력한 번호 : {0}", currPassword);
    }

    public void OnEnterPassword()
    {
        if (password == currPassword)
        {
            Debug.Log("문 열림");
            door.SetDoorAnimation(true);

            gameObject.SetActive(false); // DoorLock UI 끄기
            currPassword = String.Empty;
            passwordText.text = $"입력한 번호 : {currPassword}";
        }
        else
        {
            Debug.Log("비밀번호 틀림");
            currPassword = String.Empty;
            passwordText.text = $"입력한 번호 : {currPassword}";
            // currPassword = "";
        }
    }
}