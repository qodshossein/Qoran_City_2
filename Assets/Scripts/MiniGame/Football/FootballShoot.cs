using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Football
{
    public class FootballShoot : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private float shootForce;
        [SerializeField] private Joystick joystick;

        private bool _shoot;
        private void Update()
        {
            if(joystick.Pressed)
                _shoot = true;
            if (_shoot && !joystick.Pressed)
            {
                var distance = Vector3.Distance(transform.position, ball.position);
                if(distance <= 0.8) 
                {
                    ball.velocity = transform.right * shootForce;
                    _shoot = false;
                }
            }
        }
    }
}
