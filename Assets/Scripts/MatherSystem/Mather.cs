using System.Collections;
using Animals;
using Animals.Tails;
using MatherSystem.Sounds;
using Tails;
using UnityEngine;
using Zenject;

namespace MatherSystem
{
    public class Mather : MonoBehaviour
    {
        [SerializeField] private MatherSounds sounds;
        [SerializeField] private MatherHelp helps;
        [SerializeField] private float timeToHelp;
        
        private AnimalSpawner _animalSpawner;
        private TailSpawner _tailSpawner;
        private Coroutine _timerCoroutine;
        private Animal _currentAnimal;
        private Tail _correctTail;

        private bool _pointerShows;
        private float _timer;

        [Inject]
        private void Construct(TailSpawner tailSpawner, AnimalSpawner animalSpawner)
        {
            _tailSpawner = tailSpawner;
            _animalSpawner = animalSpawner;
        }
        
        private void Awake()
        {
            _animalSpawner.OnAnimalSpawned += OnAnimalSpawned;
        }

        private void Start()
        {
            _timer = 0;
            StartTimer();
        }

        private void OnAnimalSpawned(Animal animal)
        {
            _currentAnimal = animal;
            _currentAnimal.OnCorrectTailDropped += sounds.OnCorrectTail;
            _currentAnimal.OnCorrectTailDropped += StopTimer;
            _currentAnimal.OnIncorrectTailDropped += sounds.OnIncorrectTail;
        }

        private void StartTimer()
        {
            if(_timerCoroutine != null) StopCoroutine(_timerCoroutine);
            _timerCoroutine = StartCoroutine(MotherTimer());
        }

        private void StopTimer()
        {
            if(_timerCoroutine != null) StopCoroutine(_timerCoroutine);
            _timer = 0;
            _pointerShows = true;
        }

        private IEnumerator MotherTimer()
        {
            _timer += Time.deltaTime;
            yield return new WaitUntil(() => _timer >= timeToHelp);
            FirstStep();
            yield return new WaitUntil(() => _timer >= timeToHelp * 2);
            SecondStep();
        }

        private void Update()
        {
            Timer();
        }

        private void Timer()
        {
            if (_pointerShows)
            {
                _timer = 0;
                return;
            }
            
            var touches = Input.GetMouseButtonDown(0);
#if !UNITY_EDITOR
            touches = Input.touchCount > 0;
#endif
            if (!touches)
            {
                _timer += Time.deltaTime;
            }
            else 
            {
                _timer = 0f;
            }
        }

        private void FirstStep()
        {
            _currentAnimal.PlayQuestion();
            _tailSpawner.PulseAllTails();
        }

        private void SecondStep()
        {
            _correctTail = _tailSpawner.CorrectTail;
            _currentAnimal.PlayQuestion();
            helps.ShowPointer(_correctTail);
            _pointerShows = true;
            _correctTail.OnStartDrag += CurrentTailOnStartDragged;
        }

        private void CurrentTailOnStartDragged()
        {
            helps.Hide();
            _correctTail.OnStartDrag -= CurrentTailOnStartDragged;
            _correctTail.OnStopDrag += CurrentTailOnEndDragged;
        }

        private void CurrentTailOnEndDragged()
        {
            _pointerShows = false;
            _correctTail.OnStopDrag -= CurrentTailOnEndDragged;
            StartTimer();
        }
    }
}