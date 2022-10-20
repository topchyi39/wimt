using Animals.Data;
using Tools.Spine;
using UnityEngine;
using Visual;
using AnimationState = Spine.AnimationState;

namespace Animals.Visual
{
    public class AnimalVisual : Object2DVisual
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        
        private AnimateSpine _animateSpine;
        private AnimationState _animationState;
        private AnimalAnimationData _animationData;
        private AnimalData _animalData;

        private int _wrongCount;
        
        public void Initialize(AnimationState animationState, AnimalData animalData)
        {
            _animationState = animationState;
            _animalData = animalData;
            _animationData = _animalData.Animations;
            _animateSpine = new AnimateSpine(_animationState, _animationData.IdleAnimation);
            
            SetIdle();
        }

        public void SetSpriteToTail(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void SetIdle()
        {
            _animateSpine.SetAnimation(_animationData.IdleAnimation);
        }

        public void SetWrong()
        {
            _animateSpine.SetAnimation(_animationData.WrongTailAnimation);
        }

        public void SetTap()
        {
            _animateSpine.SetAnimation(_animationData.TapAnimation);
        }

        public void SetSad()
        {
            _animateSpine.SetAnimation(_animationData.SadAnimation);
        }
        
        public void SetRight()
        {
            _animateSpine.SetAnimation(_animationData.RightTailAnimation);
        }
    }
}