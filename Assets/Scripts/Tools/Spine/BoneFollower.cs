using System;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Tools.Spine
{
    public class BoneFollower : MonoBehaviour
    {
        [SerializeField] private SkeletonRenderer skeletonRenderer;

        private Bone bone;
        
        public void Initialize(string boneName)
        {
            bone = skeletonRenderer.skeleton.FindBone(boneName);
        }
        
        private void Update()
        {
            if (bone == null) return;
            transform.position = bone.GetWorldPosition(skeletonRenderer.transform);
            transform.rotation = bone.GetQuaternion();
        }
    }
}