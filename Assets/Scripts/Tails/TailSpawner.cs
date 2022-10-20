using System.Collections.Generic;
using System.Linq;
using Animals;
using Animals.Data;
using Animals.Tails;
using UI.Tools;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Tails
{
    public class TailSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] pointsToSpawn;
        [SerializeField] private Tail tailPrefab;
        [SerializeField] private RectCorrector rectCorrector;
        

        private Tail _correctTail;
        private List<Tail> _tails = new();
        private List<TailData> _generatedData;
        private AnimalHolder _animalHolder;

        public Tail CorrectTail => _correctTail;

        [Inject]
        private void Construct(AnimalHolder animalHolder)
        {
            _animalHolder = animalHolder;
        }

        private void Start()
        {
            GenerateTails();
        }

        private void GenerateTails()
        {
            var random = new Random();
            var tails = _animalHolder.Animals.Select(animal => animal.TailData);
            var list = CheckForSelectedTail(tails);
            _generatedData = list.OrderBy(a => random.Next()).ToList();
            SpawnTails(_generatedData);
        }

        private IEnumerable<TailData> CheckForSelectedTail(IEnumerable<TailData> tails)
        {
            var list = tails.ToList();
            var selectedTail = _animalHolder.SelectedAnimal.TailData;
            if (list.Contains(selectedTail))
            {
                list.Remove(selectedTail);
            }

            var delta = list.Count + 1 - pointsToSpawn.Length;
            
            if (delta > 0)
            {
                list.RemoveRange(0 ,delta);
            }
            
            list.Add(selectedTail);

            return list;
        }
        
        public void PulseAllTails()
        {
            foreach (var tail in _tails)
            {
                tail.Pulse();
            }
        }

        private void SpawnTails(List<TailData> tailsData)
        {
            for (var i = 0; i < pointsToSpawn.Length; i++)
            {
                var point = pointsToSpawn[i];
                var tailData = tailsData[i];
                var tail = Instantiate(tailPrefab, point.position, Quaternion.identity, point);
                tail.SetData(tailData);
                rectCorrector.Correct((RectTransform) tail.transform);
                _tails.Add(tail);
            }

            _correctTail = _tails.Find(item => _animalHolder.SelectedAnimal.CompareTails(item.TailData));
        }
    }
}