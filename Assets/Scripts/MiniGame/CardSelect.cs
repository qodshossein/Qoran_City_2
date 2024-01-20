using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class CardSelect : MonoBehaviour
    {
        public Sprite sprite;
        public UnityEvent<CardSelect> OnSelect;

        private SpriteRenderer[] _spriteRenderers;
        private Vector3 _firstRotate;
        private bool _rotate;
        private void Awake()
        {
            _firstRotate = transform.eulerAngles;

            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }
        private void OnMouseUp()
        {
            if (!_rotate) 
            {
                Rotate();
                OnSelect?.Invoke(this);
            }
        }

        public void Rotate() 
        {
            var targetRotate = new Vector3(_firstRotate.x, 180, _firstRotate.z);
            var animationTime = 0.5f;
            transform.DORotate(targetRotate, animationTime).SetEase(Ease.Linear).OnComplete(() =>
            {

            });
            Invoke(nameof(ChangeLyers), animationTime / 2);
            _rotate = true;
        }
        public void BackToFirstRotate() 
        {
            var animationTime = 0.5f;
            transform.DORotate(_firstRotate, animationTime).SetEase(Ease.Linear).OnComplete(() =>
            {

            });
            Invoke(nameof(ChangeLyers), animationTime / 2);
            _rotate = false;
        }

        private void ChangeLyers() 
        {
            for (int i = 1; i < _spriteRenderers.Length; i++)
            {
                _spriteRenderers[i].sortingOrder = _rotate ? 1 : 0;
            }
            _spriteRenderers[0].sortingOrder = _rotate ? 0 : 1;
        }

        public void Show() 
        {
            Invoke(nameof(Rotate), 0.5f);
            Invoke(nameof(BackToFirstRotate), 1.5f);
        }
    }
}
