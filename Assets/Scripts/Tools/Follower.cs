using UnityEngine;

namespace Tools
{
    public class Follower : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _positionMultiplier;

        public void SetTarget(Transform target, Vector3 positionMultiplier)
        {
            _target = target;
            _positionMultiplier = positionMultiplier;
        }
        
        private void Update()
        {
            if (!_target) return;

            transform.position = _target.position + _positionMultiplier;
            transform.rotation = _target.rotation;
        }
    }
}