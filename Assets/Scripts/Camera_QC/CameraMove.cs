using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Camera_PX
{
    public class CameraMove : MonoBehaviour
    {
        public static CameraMove Instance {  get; private set; }

        [SerializeField] private Transform target;
        [SerializeField] private Transform pivot;
        [SerializeField] private float speedMove;
        [SerializeField] private Vector2 speedRotate;
        [SerializeField] private float minRotateY;
        [SerializeField] private float maxRotateY;

        private float rotateX;
        private float rotateY;
        private bool _canFollow;

        private void Awake()
        {
            Instance = this;

            rotateX = transform.localScale.y;
            rotateY = transform.localScale.x;
            _canFollow = true;
        }
        private void LateUpdate()
        {
            if (_canFollow)
                Move();
        }
        private void Move() 
        {
            if (!target) return;

            var pos = target.position;
            var targetPos = Vector3.Lerp(transform.position, pos, speedMove * Time.deltaTime);
            transform.position = targetPos;

            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            rotateX += mouseX * speedRotate.x * Time.fixedDeltaTime;
            rotateY += mouseY * speedRotate.y * Time.fixedDeltaTime;
            rotateY = Mathf.Clamp(rotateY, minRotateY, maxRotateY);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotateX, transform.eulerAngles.z);
            pivot.localEulerAngles = new Vector3(-rotateY, pivot.localEulerAngles.y, pivot.localEulerAngles.z);
        }

        public void AnactiveFollow() => _canFollow = true;
        public void InactiveFollow() => _canFollow = false;
    }
}
