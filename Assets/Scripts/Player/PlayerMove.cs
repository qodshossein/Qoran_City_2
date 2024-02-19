using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotateTime = 0.1f;

        private float _refrenceAngle;

        public bool CanRotation { get; set; }
        
        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var move = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));
            var diraction = new Vector3(horizontal, 0, vertical);
            
            if (diraction.magnitude > 0.1f)
            {
                var camera = Camera.main.transform;
                var angel = Mathf.Atan2(diraction.x, diraction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
                var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angel, ref _refrenceAngle, rotateTime);

                transform.eulerAngles = new Vector3(0, smoothAngle, 0);
            }

            transform.Translate(0, 0, move * speed * Time.deltaTime);
        }
    }
}
