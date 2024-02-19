using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera_PX
{
    public class CameraCollision : MonoBehaviour
    {
        public static CameraCollision Instance {  get; private set; }

        [SerializeField] private Transform originPoint;
        [SerializeField] private LayerMask collisionMask;

        private Transform _camera;
        private float maxDistance;
        private GameObject _targetPoint;
        private bool _canCollision;
        private void Awake()
        {
            Instance = this;

            _camera = Camera.main.transform;
            _targetPoint = new GameObject("Target Cast");

            _targetPoint.transform.parent = _camera.parent;
            _targetPoint.transform.localPosition = _camera.localPosition;
            _targetPoint.transform.localRotation = _camera.localRotation;
            maxDistance = _targetPoint.transform.localPosition.z;

            _canCollision = true;
        }

        private void Update()
        {
            if (_canCollision)
                CheckObstacle();
        }

        private void CheckObstacle() 
        {
            var origin = originPoint.position;
            var targetPoint = _targetPoint.transform.position - _targetPoint.transform.forward;
            RaycastHit hit;
            var collision = Physics.Linecast(origin, targetPoint, out hit, collisionMask);

            var cameraPosition = _camera.localPosition;
            if (collision && hit.distance < Mathf.Abs(maxDistance))
            {
                cameraPosition.z = -hit.distance;
                cameraPosition.z += 1;
            }
            else
            {
                cameraPosition.z = maxDistance;
            }

            _camera.localPosition = Vector3.Lerp(_camera.localPosition, cameraPosition, 5 * Time.deltaTime);
            Debug.DrawLine(origin, targetPoint, Color.white);
        }

        public void ActiveCollision() => _canCollision = true;
        public void InactiveCollision() => _canCollision = false;
    }
}
