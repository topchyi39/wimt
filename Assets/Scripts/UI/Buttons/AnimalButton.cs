using System;
using Animals;
using Animals.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class AnimalButton : MonoBehaviour
    {
        [SerializeField] private Image animalIcon;
        [SerializeField] private Button button;
        
        private AnimalData _currentAnimalData;
        
        
        public void SetAnimal(AnimalData animalData, UnityAction<AnimalData> onClick)
        {
            _currentAnimalData = animalData;
            
            animalIcon.sprite = _currentAnimalData.Icon;
            button.onClick.AddListener(() => onClick?.Invoke(_currentAnimalData));
        }
        
        
    }
}