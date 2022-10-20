using Animals;
using Extensions;
using UnityEngine;

namespace MatherSystem.Sounds
{
    public class MatherSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private MotherSoundsData sounds;

        private Animal _currentAnimal;
        
        private void Awake()
        {
            sounds.ClearUnusedClips();
        }
        
        public void OnCorrectTail()
        {
            audioSource.SetClipAndPlay(sounds.GetCorrect());
        }
        
        public void OnIncorrectTail()
        {
            audioSource.SetClipAndPlay(sounds.GetIncorrect());
        }
    }
}