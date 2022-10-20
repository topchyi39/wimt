using Animals.Data;
using Animals.Tails;
using Animals.Visual;
using Spine;
using Spine.Unity;
using UI.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using BoneFollower = Tools.Spine.BoneFollower;

namespace Animals
{
    public class Animal : MonoBehaviour, IPointerDownHandler
    {
        [Header("References")]
        [SerializeField] private SkeletonAnimation skeletonGraphic;
        [SerializeField] private TailDropReceiver dropReceiver;
        [SerializeField] private BoneFollower boneFollower;
        [SerializeField] private AnimalSounds sounds;
        [SerializeField] private AnimalVisual visual;
        
        [Header("Events")] 
        [SerializeField] private UnityEvent onCorrectTailDropped;
        [SerializeField] private UnityEvent onIncorrectTailDropped;

        
           
        private AnimalData _animalData;
        private Slot _tailSlot;
        private Attachment _defaultAttachment;
        private Recenter _recenterTool;
        
        public Vector3 PivotOffset => _recenterTool.Delta;

        public event UnityAction OnCorrectTailDropped
        {
            add => onCorrectTailDropped.AddListener(value);
            remove => onCorrectTailDropped.RemoveListener(value);
        }
        
        public event UnityAction OnIncorrectTailDropped
        {
            add => onIncorrectTailDropped.AddListener(value);
            remove => onIncorrectTailDropped.RemoveListener(value);
        }

        private void Awake()
        {
            _recenterTool = new Recenter((RectTransform) transform);
            dropReceiver.OnDropped += OnTailDropped;
        }
        
        public void SetData(AnimalData data)
        {
            _animalData = data;
            sounds.Initialize(_animalData.Sounds);
            Generate();
            visual.Initialize(skeletonGraphic.AnimationState, _animalData);
            boneFollower.Initialize(_animalData.TailBone);
        }

        public void PlayQuestion()
        {
            sounds.PlayStart();
        }
        
        private void Generate()
        {
            _tailSlot = _animalData.SetDataAndGetTail(skeletonGraphic);
            DisableTail();
            _recenterTool.RecenterTarget();
        }
        
        private void OnTailDropped(Tail droppedTail)
        {
            if (!_animalData.CompareTails(droppedTail.TailData))
                Failed(droppedTail);
            else
                Success(droppedTail);
        }

        private void Failed(Tail droppedTail)
        {
            DisableTail();
            visual.SetSpriteToTail(droppedTail.TailData.TailSpriteSlot);
            onIncorrectTailDropped?.Invoke();
                
            var isSad = droppedTail.FailedDrop();

            if(isSad)
                visual.SetSad();
            else
                visual.SetWrong();
        }

        private void Success(Tail droppedTail)
        {
            EnableTail();
            visual.SetSpriteToTail(null);
            droppedTail.SuccessfulDrop();
            onCorrectTailDropped?.Invoke();
            visual.SetRight();
        }
        
        private void DisableTail()
        {
            _defaultAttachment ??= _tailSlot.Attachment;
            _tailSlot.Attachment = null;
        }
        
        private void EnableTail()
        {
            _tailSlot.Attachment = _defaultAttachment;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            visual.SetTap();
        }
    }
}