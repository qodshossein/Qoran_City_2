using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float rotateTime;
    [SerializeField] private bool rotateY;

    private float _angleRef;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        var h = joystick.Horizontal;
        var v = joystick.Vertical;

        var move = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
        var dir = new Vector2 (h, v);

        if(dir.magnitude > 0.1f) 
        {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            var smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, angle, ref _angleRef, rotateTime);
            transform.eulerAngles = new Vector3(0,0, smoothAngle);

            transform.Translate(move * speed * Time.deltaTime, 0, 0);

            if(rotateY) 
            {
                var changeScale = transform.localScale.y > 0 && h < 0 || transform.localScale.y < 0 && h > 0;

                var targetScale = transform.localScale;
                targetScale.y = changeScale ? targetScale.y * -1 : targetScale.y;
                transform.localScale = targetScale;
            }
        }

        if (_animator) 
        {
            _animator.SetFloat("Move", move);
        }
    }
}
