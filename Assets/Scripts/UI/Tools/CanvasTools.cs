using UI.DragAndDrop;
using UnityEngine;

namespace UI.Tools
{
    public static class CanvasTools
    {
        public static void SetVisible(this DraggableObject target, bool visible)
        {
            var targetCanvas = target.CanvasGroup;
            targetCanvas.alpha = visible ? 1f : 0f;
            targetCanvas.interactable = visible;
            targetCanvas.blocksRaycasts = visible;
        }

        public static void SetVisible(this CanvasGroup targetCanvas, bool visible)
        {
            targetCanvas.alpha = visible ? 1f : 0f;
            targetCanvas.interactable = visible;
            targetCanvas.blocksRaycasts = visible;
        }
    }
}