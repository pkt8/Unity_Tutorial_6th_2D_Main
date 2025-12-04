using UnityEngine;

namespace Platformer
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource bgmAudio;
        public AudioSource eventAudio;
        public AudioClip[] clips;

        public void SoundPlay(int index) // 배경음악 용도
        {
            bgmAudio.clip = clips[index];
            bgmAudio.loop = true;
            bgmAudio.Play();
        }

        public void SoundOneShot(int index) // 이벤트 사운드 용도
        {
            eventAudio.PlayOneShot(clips[index]);
        }
    }
} 