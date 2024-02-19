using Camera_PX;
using DG.Tweening;
using Shop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private Vector3 _cameraFirstPos;
        private Quaternion _cameraFirstRot;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Store shop))
            {
                var playerPoint = shop.PlayerPoint;
                var cameraPoint = shop.CameraPoint;

                var camera = Camera.main.transform;
                _cameraFirstPos = camera.localPosition;
                _cameraFirstRot = camera.localRotation;

                CameraMove.Instance.InactiveFollow();
                CameraCollision.Instance.InactiveCollision();
                camera.DOMove(cameraPoint.position, 0.5f);
                camera.DORotateQuaternion(cameraPoint.rotation, 0.5f);

                transform.DOMove(playerPoint.position, 0.5f);
                transform.DORotateQuaternion(playerPoint.rotation, 0.5f);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Store shop))
            {
                var camera = Camera.main.transform;
                CameraMove.Instance.AnactiveFollow();
                CameraCollision.Instance.ActiveCollision();
                camera.DOLocalMove(_cameraFirstPos, 0.5f);
                camera.DOLocalRotateQuaternion(_cameraFirstRot, 0.5f);
            }
        }
    }
}
