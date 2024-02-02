using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class StrafMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Joystick joystick;

        private void Update()
        {
            var h = joystick.Horizontal;
            var v = joystick.Vertical;
            h*=speed; v*=speed;
            transform.Translate(new Vector3(h, v, 0) * Time.deltaTime);
        }
    }
}
