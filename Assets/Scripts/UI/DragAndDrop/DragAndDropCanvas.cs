using System;
using UnityEngine;

namespace UI.DragAndDrop
{
    public class DragAndDropCanvas : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        public static Canvas MainCanvas { get; private set; }

        private void Start()
        {
            MainCanvas = canvas;
        }

        private void OnDestroy()
        {
            MainCanvas = null;
        }
    }
}