using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace MatherSystem.Sounds
{
    [CreateAssetMenu(fileName = "MotherSounds", menuName = "Mother/Sounds/Data", order = 0)]
    public class MotherSoundsData : ScriptableObject
    {
        [SerializeField] private AudioClip[] incorrectClips;
        [SerializeField] private AudioClip[] correctClips;

        private List<AudioClip> notUsedIncorrectClips = new ();
        private List<AudioClip> notUsedCorrectClips = new ();
        
        private Random random;

        public void ClearUnusedClips()
        {
            notUsedIncorrectClips.Clear();
            notUsedCorrectClips.Clear();
        }
        
        public AudioClip GetIncorrect()
        {
            random ??= new Random();
            
            if (notUsedIncorrectClips.Count == 0)
            {
                notUsedIncorrectClips.AddRange(incorrectClips);
            }
            
            var index = random.Next(0, notUsedIncorrectClips.Count);
            var clip = notUsedIncorrectClips[index];
            notUsedIncorrectClips.Remove(clip);
            return clip;
        }
        
        public AudioClip GetCorrect()
        {
            random ??= new Random();
            
            if (notUsedCorrectClips.Count == 0)
            {
                notUsedCorrectClips.AddRange(correctClips);
            }
            
            var index = random.Next(0, notUsedCorrectClips.Count);
            var clip = notUsedCorrectClips[index];
            notUsedCorrectClips.Remove(clip);
            return clip;
        }
    }
}