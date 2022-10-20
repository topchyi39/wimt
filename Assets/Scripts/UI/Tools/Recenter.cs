using UnityEngine;

namespace UI.Tools
{
    public class Recenter
    {
        private RectTransform _transform;
        private Vector2 _defaultPivot;
        private Vector3 _delta;

        public Vector3 Delta => _delta;
        
        public Recenter(RectTransform transform)
        {
            _transform = transform;
            _defaultPivot = _transform.pivot;
        }

        public void RecenterTarget()
        {
            var pivot = _defaultPivot - _transform.pivot;
            _delta = new Vector3(pivot.x * _transform.sizeDelta.x, pivot.y * _transform.sizeDelta.y);
            _transform.localPosition =  _transform.localPosition - _delta;
        }
    }
}