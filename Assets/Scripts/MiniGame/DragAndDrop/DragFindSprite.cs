using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using MiniGame.Finder;

namespace MiniGame.DragAndDrop
{
    public class DragFindSprite : Drag
    {
        [SerializeField] private bool failAnimation;

        public UnityEvent OnRelese;
        public UnityEvent OnDrop;
        private Vector3 _firstScale;

        protected override void Start()
        {
            base.Start();
            _firstScale = transform.localScale;
        }
        protected override void OnMouseUp()
        {
            base.OnMouseUp();
            if (!CanDrag) return;
            var slot = MouseData.SlotObject;
            if (slot)
            {
                var spriteFinder = slot.GetComponent<TypeFinder>();

                if (spriteFinder.Check(_spriteRenderer.sprite))
                    TrueSlot(slot);
                else
                    WrongSlot();
            }
            else
                WrongSlot();
        }

        private void TrueSlot(Slot slot) 
        {
            OnDrop?.Invoke();
            transform.position = slot.TargetPosition.position;
            transform.parent = slot.TargetPosition;
            if (_spriteRenderer)
                _spriteRenderer.sortingOrder = targetLayerOrder;

            if (slot.JustOnDrop)
                slot.CanDrop = false;
            CanDrag = false;
            MouseData.SlotObject = null;
        }
        private void WrongSlot() 
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
