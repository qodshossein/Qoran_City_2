using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] protected int targetLayerOrder;
        public UnityEvent OnGrap;

        protected bool _select;
        protected Vector3 _firstPos;
        protected Collider2D _collider;
        protected SpriteRenderer _spriteRenderer;
        protected int _firstLayer;

        public bool CanDrag { get; set; }
        protected virtual void Start()
        {
            _firstPos = transform.localPosition;
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer)
                _firstLayer = _spriteRenderer.sortingOrder;

            CanDrag = true;
        }
        protected virtual void Update()
        {
            if (_select && CanDrag)
                Move();
        }
        protected virtual void OnMouseDown()
        {
            if(!CanDrag) return;
            _select = true;

            MouseData.DragObject = this;
            _collider.enabled = false;
            if (_spriteRenderer)
                _spriteRenderer.sortingOrder = targetLayerOrder;

            OnGrap?.Invoke();
        }
        protected virtual void OnMouseUp()
        {
            if(!CanDrag) return;
            _select = false;

            MouseData.DragObject = null;
            _collider.enabled = true;
        }

        protected virtual void Move()
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
}
