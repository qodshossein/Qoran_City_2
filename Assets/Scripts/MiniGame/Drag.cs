using Tween;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] private bool failAnimation;
        [SerializeField] protected int targetLayerOrder;
        [SerializeField] protected AnimationTween[] animations;
        public UnityEvent OnGrap;
        public UnityEvent OnRelese;
        public UnityEvent OnDrop;

        protected bool _select;
        protected Vector3 _firstPos;
        protected Collider2D _collider;
        protected SpriteRenderer _spriteRenderer;
        protected int _firstLayer;
        protected Vector3 _firstScale;

        public bool CanDrag { get; set; }
        protected virtual void Start()
        {
            _firstPos = transform.localPosition;
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer)
                _firstLayer = _spriteRenderer.sortingOrder;

            _firstScale = transform.localScale;
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

        protected virtual void TrueSlot(Slot slot)
        {
            OnDrop?.Invoke();
            if (slot.TargetPosition)
            {
                transform.position = slot.TargetPosition.position;
                transform.parent = slot.TargetPosition;
            }
            if (_spriteRenderer)
                _spriteRenderer.sortingOrder = targetLayerOrder;

            if (slot.JustOnDrop)
                slot.CanDrop = false;
            CanDrag = false;
            MouseData.SlotObject = null;

            for (int i = 0; i < animations.Length; i++)
            {
                animations[i].Play();
            }
        }
        protected virtual void WrongSlot()
        {
            OnRelese?.Invoke();
            if (failAnimation)
            {
                transform.DOShakeScale(0.5f, 1, 15, 90).OnComplete(() =>
                {
                    transform.DOScale(_firstScale, 0.1f);
                    transform.DOLocalMove(_firstPos, 0.1f);
                    if (_spriteRenderer)
                        _spriteRenderer.sortingOrder = _firstLayer;
                });
            }
            else
            {
                transform.DOLocalMove(_firstPos, 0.1f);
                if (_spriteRenderer)
                    _spriteRenderer.sortingOrder = _firstLayer;
            }
        }
    }
}
