using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.BubbleShooter
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float shootForce;
        [SerializeField] private Rigidbody2D[] bulletsPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private SpriteRenderer spriteHelp;

        private Rigidbody2D _bullet;


        private void Awake()
        {
            ChoiceBullet();
        }


        private void Update()
        {
            if (Input.GetMouseButton(0))
                Aim();
            if(Input.GetMouseButtonUp(0))
                Shoot();
        }

        private void Aim() 
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            var diraction = mousePosition - transform.position;

            transform.up = diraction;
        }
        private void Shoot() 
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            var diraction = mousePosition - shootPoint.position;
            shootPoint.up = diraction;

            var bullet = Instantiate(_bullet, shootPoint.position, shootPoint.rotation);
            bullet.velocity = shootPoint.up * shootForce;

            ChoiceBullet();

            MiniGameController.Instance.OnFail();
        }
        private void ChoiceBullet()
        {
            var randomIndex = Random.Range(0, bulletsPrefab.Length);
            _bullet = bulletsPrefab[randomIndex];
            var sprite = _bullet.GetComponent<SpriteRenderer>().sprite;

            spriteHelp.sprite = sprite;
        }
    }
}
