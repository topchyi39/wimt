using System;
using UnityEngine;

namespace UI.Tools
{
    [Serializable]
    public class RectCorrector
    {
        [SerializeField] private float maxHeight;
        [SerializeField] private float maxWidth;


        public void Correct(RectTransform transform)
        {
            var ratio = Vector2.zero;
            var sizeDelta = transform.sizeDelta;
            var multiplier = 1f;
            if (sizeDelta.x > sizeDelta.y)
            {
                ratio = new Vector2(1, sizeDelta.y / sizeDelta.x);
                multiplier = maxWidth;
            }

            if (sizeDelta.y >= sizeDelta.x)
            {
                ratio = new Vector2(sizeDelta.x / sizeDelta.y ,1);
                multiplier = maxHeight;
            }

            transform.sizeDelta = ratio * multiplier;
        }
    }
}