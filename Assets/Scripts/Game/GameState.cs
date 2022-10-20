using System;
using System.Collections;
using Animals;
using SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private float delayForMenuLoad;
        
        private AnimalSpawner _animalSpawner;
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader, AnimalSpawner animalSpawner)
        {
            _sceneLoader = sceneLoader;
            _animalSpawner = animalSpawner;
            _animalSpawner.OnAnimalSpawned += animal => animal.OnCorrectTailDropped += OnCorrect;
        }
        
        private void OnCorrect()
        {
            StartCoroutine(FinishGameRoutine());
        }

        private IEnumerator FinishGameRoutine()
        {
            yield return new WaitForSeconds(delayForMenuLoad);
            _sceneLoader.LoadMenuScene();
        }
    }
}