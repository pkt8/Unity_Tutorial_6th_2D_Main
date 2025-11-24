using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public VideoPlayer video;
    public VideoClip[] videoClips;
    public int currChannel = 0;
    
    public Button[] remoteButtons;

    public GameObject screen;
    private bool isScreenOn = false; // 처음에 스크린이 꺼져있는 상태
    private bool isMute = false;

    void Awake()
    {
        video.clip = videoClips[0];
    }
    
    void Start()
    {
        remoteButtons[0].onClick.AddListener(PowerButton);
        remoteButtons[1].onClick.AddListener(MuteButton);
        remoteButtons[2].onClick.AddListener(PrevChannelButton);
        remoteButtons[3].onClick.AddListener(NextChannelButton);
    }

    private void PowerButton()
    {
        isScreenOn = !isScreenOn; // 현재 상태를 반대로 뒤집는 기능
        
        screen.SetActive(isScreenOn); // 반대로 변경된 상태로 스크린에 적용
        
        // if (screen.activeSelf) // 스크린이 켜져있다면
        //     screen.SetActive(false);
        // else // 스크린이 꺼져있다면
        //     screen.SetActive(true);
    }

    private void MuteButton()
    {
        isMute = !isMute;
        
        video.SetDirectAudioMute(0, isMute);
        
        Debug.Log($"음소거 : {isMute}");
        
        // if (video.GetDirectAudioMute(0) == true)
        //     video.SetDirectAudioMute(0, false);
        // else if (video.GetDirectAudioMute(0) == false)
        //     video.SetDirectAudioMute(0, true);
        
        // audio.mute = true; // 음소거
        // audio.mute = false; // 음소거 해제
    }

    private void PrevChannelButton()
    {
        currChannel--;

        if (currChannel < 0)
            currChannel = videoClips.Length - 1;
        
        video.clip = videoClips[currChannel];
        video.Play();
    }

    private void NextChannelButton()
    {
        currChannel++;

        if (currChannel >= videoClips.Length)
            currChannel = 0;
        
        video.clip = videoClips[currChannel];
        video.Play();
    }
}