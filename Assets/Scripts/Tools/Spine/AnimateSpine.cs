using Animals.Data;
using UnityEngine;
using Animation = Spine.Animation;
using AnimationState = Spine.AnimationState;

namespace Tools.Spine
{
    public class AnimateSpine
    {
        private readonly AnimationState _animationState;
        private readonly Animation _defaultAnimation;
        
        public AnimateSpine(AnimationState animationState, Animation defaultAnimation)
        {
            _animationState = animationState;
            _defaultAnimation = defaultAnimation;
        }

        public void SetAnimation(Animation animation, bool loop = false)
        {
            _animationState.SetAnimation(0, animation, loop);
            
            if(!loop)
                _animationState.AddAnimation(0, _defaultAnimation, true, animation.Duration);
        }
    }
}