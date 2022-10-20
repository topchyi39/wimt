using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Animals
{
    public class AnimalSpawner : MonoBehaviour
    {
        [SerializeField] private Animal animalPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private UnityEvent<Animal> onAnimalSpawned;
        
        private Animal _currentAnimal; 
        private AnimalHolder _animalHolder;
        public event UnityAction<Animal> OnAnimalSpawned
        {
            add => onAnimalSpawned.AddListener(value);
            remove => onAnimalSpawned.RemoveListener(value);
        }

        [Inject]
        private void Construct(AnimalHolder animalHolder)
        {
            _animalHolder = animalHolder;
        }
        
        private void Start()
        {
            SpawnAnimal();
        }

        private void SpawnAnimal()
        {
            _currentAnimal = Instantiate(animalPrefab, parent);
            _currentAnimal.SetData(_animalHolder.SelectedAnimal);
            onAnimalSpawned?.Invoke(_currentAnimal);
        }
    }
}