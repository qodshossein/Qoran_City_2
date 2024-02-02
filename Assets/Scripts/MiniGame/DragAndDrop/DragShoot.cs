using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.DragAndDrop
{
    public class DragShoot : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private float force;
        [SerializeField] private Transform lineForce;
        [SerializeField] private SpriteRenderer spriteForce;
        [SerializeField] private Color minColor = Color.green;
        [SerializeField] private Color maxColor = Color.red;

        private bool _acctiveAim;
        private float _force;
        private Rigidbody2D _rigidBody;

        private bool _canShoot;
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            lineForce.localScale = new Vector3(0, lineForce.localScale.y, lineForce.localScale.z);
        }
        private void Start()
        {
            _canShoot = true;
        }
        private void Update()
        {
            if (!_canShoot) return;

            if (joystick.Pressed) 
            {
                _acctiveAim = true;
                Aim();
            }
            if (_acctiveAim && !joystick.Pressed) 
            {
                Shoot();
                _acctiveAim = false;
            }
        }

        private void Aim() 
        {
            var h = joystick.Horizontal;
            var v = joystick.Vertical;
            _force = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
            _force = Mathf.Clamp(_force, 0, 0.7f);

            var angle = Mathf.Atan2(-v, -h) * Mathf.Rad2Deg;
            lineForce.transform.eulerAngles = new Vector3(0, 0, angle);

            lineForce.localScale = new Vector3(_force, lineForce.localScale.y, lineForce.localScale.z);
            spriteForce.color = Color.Lerp(minColor, maxColor, _force * 1.2f);
        }
        private void Shoot() 
        {
            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _rigidBody.velocity = lineForce.right * _force * force;
            lineForce.localScale = new Vector3(0, lineForce.localScale.y, lineForce.localScale.z);
            _canShoot = false;
        }
        public void ActiveAim() 
        {
            _rigidBody.bodyType = RigidbodyType2D.Kinematic;
            _rigidBody.velocity = Vector2.zero;
            _canShoot = true;
        }
    }
}
