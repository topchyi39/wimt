using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.DragAndDrop
{
    public abstract class OnDropReceiver<T> : MonoBehaviour, IDropHandler where T : DraggableObject
    {
        [SerializeField] private UnityEvent<T> onDropped;
        
        public event UnityAction<T> OnDropped
        {
            add => onDropped.AddListener(value);
            remove => onDropped.RemoveListener(value);
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if(eventData.pointerDrag == null) return;

            if (eventData.pointerDrag.TryGetComponent<DraggableObject>(out var draggableObject))
            {
                var castedObject = (T) draggableObject;
                onDropped?.Invoke(castedObject);
                OnObjectDropped(castedObject);
            }
        }

        protected abstract void OnObjectDropped(T draggableObject);
    }
}