using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class SwipMove : MonoBehaviour
    {
        [SerializeField] private float speedX;
        [SerializeField] private float speedY;
        [Space]
        [SerializeField] private float minXMove;
        [SerializeField] private float maxXMove;

        private Vector2 _deltaMove;
        private Vector2 _firstMousePos;
        private Vector2 _targetPos;

        private void Start()
        {
            _targetPos = transform.position;
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                _firstMousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 mousPos = Input.mousePosition;
                _deltaMove = mousPos - _firstMousePos;
                _firstMousePos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _deltaMove = Vector2.zero;
            }

            Move();
        }

        private void Move() 
        {
            var h = _deltaMove.x * speedX * Time.deltaTime;
            var v = _deltaMove.y * speedY * Time.deltaTime;
            _targetPos += new Vector2(h, v);
            _targetPos.x = Mathf.Clamp(_targetPos.x, minXMove, maxXMove);
            transform.position = _targetPos;
        }
    }
}
