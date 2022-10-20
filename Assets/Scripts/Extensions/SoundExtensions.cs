using UnityEngine;

namespace Extensions
{
    public static class SoundExtensions
    {
        public static void SetClipAndPlay(this AudioSource audioSource, AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}