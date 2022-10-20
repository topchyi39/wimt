using System;
using Spine.Unity;
using UnityEngine;
using Animation = Spine.Animation;

namespace Animals.Data
{
    [Serializable]
    public class AnimalAnimationData
    {
        [SerializeField] private AnimationReferenceAsset idleAnimation;
        [SerializeField] private AnimationReferenceAsset wrongTailAnimation;
        [SerializeField] private AnimationReferenceAsset tapAnimation;
        [SerializeField] private AnimationReferenceAsset sadAnimation;
        [SerializeField] private AnimationReferenceAsset rightTailAnimation;
        
        public Animation IdleAnimation => idleAnimation.Animation;
        public Animation WrongTailAnimation => wrongTailAnimation.Animation;
        public Animation TapAnimation => tapAnimation.Animation;
        public Animation SadAnimation => sadAnimation.Animation;
        public Animation RightTailAnimation => rightTailAnimation.Animation;
    }
}