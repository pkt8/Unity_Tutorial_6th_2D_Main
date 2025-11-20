using UnityEngine;

public class CatSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] bgmClips;
    public AudioClip[] eventClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        BGMSound(0); // Intro 배경음악
    }

    public void BGMSound(int index)
    {
        audioSource.clip = bgmClips[index];
        audioSource.Play();
    }
    
    public void EventSound(string clipName) // 이름으로 찾는 기능
    {
        foreach (AudioClip clip in eventClips)
        {
            if (clip.name == clipName)
            {
                audioSource.PlayOneShot(clip);
                break;
            }
        }
    }

    public void MuteSound(bool isMute)
    {
        if (isMute)
            audioSource.Stop();
        else
            audioSource.Play();
    }
}