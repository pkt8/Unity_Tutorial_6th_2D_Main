using UnityEngine;

public class BombSound : MonoBehaviour
{
    private AudioSource audio;

    public AudioClip bgmClip;
    public AudioClip eventClip;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();

        BGMSound();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audio.isPlaying)
                audio.Pause();
            else
                audio.Play();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audio.Stop();
        }

        if (Input.GetMouseButtonDown(0))
        {
            EventSound();
        }
    }

    public void BGMSound()
    {
        audio.clip = bgmClip;
        audio.loop = true;
        audio.playOnAwake = true;
        audio.volume = 0.3f;
        audio.mute = false;

        audio.Play(); // 사운드 재생
    }

    public void EventSound()
    {
        audio.PlayOneShot(eventClip);
    }
}