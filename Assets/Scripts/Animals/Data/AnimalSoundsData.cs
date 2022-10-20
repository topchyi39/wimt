using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Animals
{
    [CreateAssetMenu(fileName = "AnimalSounds", menuName = "Animals/Sounds/Data", order = 0)]
    public class AnimalSoundsData : ScriptableObject
    {
        [SerializeField] private AudioClip startClip;
        
        public AudioClip StartClip => startClip;

    }
}