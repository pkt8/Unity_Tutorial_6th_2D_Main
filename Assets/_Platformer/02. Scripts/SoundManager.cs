using UnityEngine;

namespace Platformer
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource[] bgmAudios;
        public AudioSource[] eventAudios;
        public AudioClip[] clips;

        public void SoundPlay(string clipName) // 배경음악 용도
        {
            foreach (var audio in bgmAudios)
            {
                if (!audio.isPlaying)
                {
                    foreach (var clip in clips)
                    {
                        if (clip.name.Equals(clipName))
                        {
                            audio.clip = clip;
                            audio.loop = true;
                            audio.Play();
                            return;
                        }
                    }
                    Debug.Log($"{clipName} 파일을 찾을 수 없습니다.");
                    return;
                }
            }
            Debug.Log($"재생 가능한 AudioSource가 없습니다.");
        }

        public void SoundOneShot(string clipName) // 이벤트 사운드 용도
        {
            foreach (var audio in eventAudios)
            {
                if (!audio.isPlaying)
                {
                    foreach (var clip in clips)
                    {
                        if (clip.name.Equals(clipName))
                        {
                            audio.PlayOneShot(clip);
                            return;
                        }
                    }
                    Debug.Log($"{clipName} 파일을 찾을 수 없습니다.");
                    return;
                }
            }
            Debug.Log($"재생 가능한 AudioSource가 없습니다.");
        }
    }
} 