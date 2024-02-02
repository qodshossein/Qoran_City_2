using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Football
{
    public class EnemyFootBall : MonoBehaviour
    {
        [SerializeField] private float shootForce;
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private Transform goal;
        [SerializeField] private float speed;

        private bool _canShoot;
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _canShoot = true;
        }
        private void Start()
        {
            _animator.SetFloat("Move", 1);
        }
        private void Update()
        {
            if (!_canShoot) return;
            var distanceBall = Vector3.Distance(ball.transform.position, transform.position);
            var distanceGoal = Vector3.Distance(goal.position, transform.position);

            if (distanceBall > 0.85f)
            {
                var dir = ball.transform.position - transform.position;
                transform.right = Vector3.MoveTowards(transform.right, dir, 5 * Time.deltaTime);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else 
            {
                var dir = goal.position - transform.position;
                transform.right = Vector3.MoveTowards(transform.right, dir, 5 * Time.deltaTime);
                transform.Translate(speed * Time.deltaTime, 0, 0);

                if(distanceGoal <= 4) 
                {
                    _canShoot = false;
                    ball.velocity = transform.right * shootForce;
                    Invoke(nameof(ActiveShoot), 2);
                    _animator.SetFloat("Move", 0);
                }
            }
        }

        private void ActiveShoot() 
        {
            _canShoot = true;
            _animator.SetFloat("Move", 1);
        }
    }
}
