using Animals;
using Animals.Data;
using SceneManagement;
using UI.Buttons;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private AnimalButton animalButtonPrefab;
        [SerializeField] private Transform parent;

        private SceneLoader _sceneLoader;
        private AnimalHolder _animalHolder;

        [Inject]
        private void Construct(AnimalHolder holder, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _animalHolder = holder;
        }
        
        private void Start()
        {
            CreateButtons(_animalHolder.Animals);
        }

        private void CreateButtons(AnimalData[] animalsData)
        {
            foreach (var animalData in animalsData)
            {
                var button = Instantiate(animalButtonPrefab, parent);
                button.SetAnimal(animalData, AnimalSelected);
            }
        }

        private void AnimalSelected(AnimalData animalData)
        {
            _animalHolder.SetAnimal(animalData);
            _sceneLoader.LoadGameScene();
        }
        
    }
}