using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.DragAndDrop
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DraggableObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private UnityEvent onStartDrag = new();
        private UnityEvent onEndDrag = new();
        private CanvasGroup _canvasGroup;
        private Camera _mainCamera;
        private Transform _defaultParent;
        
        private Vector3 _defaultPosition;
        private Vector3 _offset;
        
        public event UnityAction OnStartDrag
        {
            add => onStartDrag.AddListener(value);
            remove => onStartDrag.RemoveListener(value);
        }
        
        public event UnityAction OnStopDrag
        {
            add => onEndDrag.AddListener(value);
            remove => onEndDrag.RemoveListener(value);
        }

        public CanvasGroup CanvasGroup => _canvasGroup;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _defaultParent = transform.parent;
            _offset = ScreenToWordPosition(eventData.position) - transform.position;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            var newPosition = ScreenToWordPosition(eventData.position) - _offset;
            newPosition.z = 0;
            transform.position = newPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(DragAndDropCanvas.MainCanvas.transform);
            _defaultPosition = transform.position;
            _canvasGroup.blocksRaycasts = false;
            onStartDrag?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_defaultParent);
            transform.position = _defaultPosition;
            _canvasGroup.blocksRaycasts = true;
            onEndDrag?.Invoke();
        }

        private Vector3 ScreenToWordPosition(Vector2 screenPosition)
        {
            var vector = _mainCamera.ScreenToWorldPoint(screenPosition);
            vector.z = 0;
            return vector;
        }

        
    }
}