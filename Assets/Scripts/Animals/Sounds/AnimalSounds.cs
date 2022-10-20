using Extensions;
using UnityEngine;

namespace Animals
{
    public class AnimalSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        
        private AnimalSoundsData _soundsData;

        public void Initialize(AnimalSoundsData soundsData)
        {
            _soundsData = soundsData;
            PlayStart();
        }

        public void PlayStart()
        {
            audioSource.SetClipAndPlay(_soundsData.StartClip);
        }

        public void PlaySuccess()
        {
            
        }
        
        public void PlayFailed()
        {
            
        }
    }
}