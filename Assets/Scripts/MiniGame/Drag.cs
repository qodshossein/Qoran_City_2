using Tween;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tools_QC;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] protected bool failAnimation;
        [SerializeField] protected bool canMoveToFirstPoint = true;
        [SerializeField] protected bool canDragAfterDrop;
        [SerializeField] protected int targetLayerOrder;
        [SerializeField] protected AnimationTween[] animations;
        [SerializeField] protected bool changeScaleOnDrop;
        [SerializeField] protected Vector3 targetScaleOnDrop;

        public UnityEvent OnGrap;
        public UnityEvent OnRelese;
        public UnityEvent OnDrop;

        protected bool _select;
        protected Vector3 _firstPos;
        protected Collider2D _collider;
        protected SpriteRenderer _spriteRenderer;
        protected int _firstLayer;
        protected Vector3 _firstScale;
        protected Slot _slot;
        protected Transform _firstParent;

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

            _firstParent = transform.parent;
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

            if (_slot) 
            {
                _slot.CanDrop = true;
                _slot = null;
            }
            transform.parent = _firstParent;
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
            if (slot.pointCreators.Length > 0)
            {
                var randomIndex = Random.Range(0, slot.pointCreators.Length);
                var point = slot.pointCreators[randomIndex].GetPoint();

                transform.position = point;
                transform.parent = slot.pointCreators[randomIndex].transform;
            }
            else
            {
                if (slot.TargetPosition)
                {
                    transform.position = slot.TargetPosition.position;
                    transform.parent = slot.TargetPosition;
                }
            }
            if (_spriteRenderer)
                _spriteRenderer.sortingOrder = targetLayerOrder;

            if (slot.JustOnDrop)
                slot.CanDrop = false;
            if (!canDragAfterDrop)
                CanDrag = false;
            MouseData.SlotObject = null;

            for (int i = 0; i < animations.Length; i++)
            {
                animations[i].Play();
            }

            if (changeScaleOnDrop)
                transform.DOScale(targetScaleOnDrop, 0.4f);

            _slot = slot;
            OnDrop?.Invoke();
            slot.OnDrop?.Invoke();
        }
        protected virtual void WrongSlot()
        {
            OnRelese?.Invoke();
            if (failAnimation)
            {
                transform.DOShakeScale(0.5f, 1, 15, 90).OnComplete(() =>
                {
                    transform.DOScale(_firstScale, 0.1f);
                    if (canMoveToFirstPoint)
                        transform.DOLocalMove(_firstPos, 0.1f);
                    if (_spriteRenderer)
                        _spriteRenderer.sortingOrder = _firstLayer;
                });
            }
            else
            {
                if (canMoveToFirstPoint)
                    transform.DOLocalMove(_firstPos, 0.1f);
                if (_spriteRenderer)
                    _spriteRenderer.sortingOrder = _firstLayer;
            }
        }
    }
}
