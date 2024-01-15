using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class ObjectMove : MonoBehaviour
    {
        [SerializeField] private Vector3 diractionMove;
        [SerializeField] private bool moveOnAwake;

        private bool _activeMove;
        private void Start()
        {
            _activeMove = moveOnAwake;
        }

        private void Update()
        {
            if (!_activeMove) return;

            transform.Translate(diractionMove * Time.deltaTime, Space.World);
        }

        public void ActiveMove()
        {
            _activeMove = true;
        }
        public void InactiveMove()
        {
            _activeMove = false;
        }
    }
}
