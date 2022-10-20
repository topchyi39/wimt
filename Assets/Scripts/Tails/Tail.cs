using System;
using Animals.Data;
using Tails;
using UI.DragAndDrop;
using UnityEngine;
using UnityEngine.UI;

namespace Animals.Tails
{
    public class Tail : DraggableObject
    {
        [SerializeField] private TailVisual tailVisual;

        [SerializeField] private Color successfulOutlineColor;
        [SerializeField] private Color failedOutlineColor;
        
        private TailData _tailData;

        public TailData TailData => _tailData;

        private int _attempts = 0;

        public void SetData(TailData data)
        {
            _tailData = data;
            tailVisual.SetImage(_tailData.TailIcon);
        }

        public void Pulse()
        {
            tailVisual.Pulse(Color.clear);
        }

        public void SuccessfulDrop()
        {
            tailVisual.Pulse(successfulOutlineColor);
        }

        public bool FailedDrop()
        {
            tailVisual.Pulse(failedOutlineColor);
            _attempts++;
            return _attempts > 1;
        }
    }
}