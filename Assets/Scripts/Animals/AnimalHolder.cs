using System;
using Animals.Data;
using UnityEngine;

namespace Animals
{
    public class AnimalHolder : MonoBehaviour
    {
        [SerializeField] private AnimalData[] animalsData;
        
        [Header("Debug")]
        [SerializeField] private AnimalData debugAnimalData;
        
        private AnimalData _selectedAnimal;
        
        public AnimalData[] Animals => animalsData;
        public AnimalData SelectedAnimal => _selectedAnimal;
        
        private void Start()
        {
            if (debugAnimalData)
                _selectedAnimal = debugAnimalData;
        }

        public void SetAnimal(AnimalData animalData)
        {
            _selectedAnimal = animalData;
        }
    }
}
