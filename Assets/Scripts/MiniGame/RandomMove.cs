using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace MiniGame
{
    public class RandomMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private PointCreator2D[] pointCreators;

        private float _firstXScale;
        private void Awake()
        {
            _firstXScale = transform.localScale.x;

            Move();
        }

        private void Move()
        {
            var pos = GetPoint();
            var scale = transform.localScale;
            if (transform.position.x > pos.x)
                scale.x = _firstXScale * -1;
            else
                scale.x = _firstXScale;

            transform.DOScale(scale, 0.3f);
            var distance = Vector3.Distance(transform.position, pos);
            var time = distance / speed;
            transform.DOMove(pos, time).OnComplete(Move).SetEase(Ease.Linear);
        }

        private Vector2 GetPoint() 
        {
            var randomIndex = Random.Range(0, pointCreators.Length);
            return pointCreators[randomIndex].GetPoint();
        }

        public void StopMove() 
        {
            transform.DOPause();
        }
    }
}
