using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.BubbleShooter
{
    public class BubbleBullet : MonoBehaviour
    {
        public int TypeValue;

        public List<BubbleBullet> BulletFinds;

        private Rigidbody2D _rigidbody;
        private bool _canDestroy;

        private void Awake()
        {
            BulletFinds = new List<BubbleBullet>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            Invoke(nameof(ActiveCanDestroy), 0.2f);
        }
        private void Update()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var otherBullet = collision.GetComponent<BubbleBullet>();
            if(!otherBullet) return;

            _rigidbody.velocity = Vector2.zero;
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;

            if (otherBullet.TypeValue != TypeValue) return;

            BulletFinds.Add(otherBullet);
            if (BulletFinds.Count >= 2)
            {
                DestroyBullets();
            }
        }
        private void ActiveCanDestroy() => _canDestroy = true;
        private void DestroyBullets() 
        {
            if (!_canDestroy) return;

            for (int i = 0; i < BulletFinds.Count; i++)
            {
                var bullet = BulletFinds[i];
                bullet.transform.DOScale(0, 0.4f).OnComplete(() =>
                {
                    Destroy(bullet.gameObject);
                });
            }
            transform.DOScale(0, 0.4f).OnComplete(() =>
            {
                Destroy(gameObject);
            });

            MiniGameController.Instance.OnFind();
        }
    }
}
