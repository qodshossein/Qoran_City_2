using MiniGame.Finder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame.Collision
{
    public class CollisionFindColor : CollisionChecker
    {
        [SerializeField] private ColorType colorType;

        [SerializeField] private bool destroySelfOut;
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            var typeFinder = other.GetComponent<TypeFinder>();
            if (typeFinder && typeFinder.Check(colorType))
            {
                if (destroyOtherObject)
                    Destroy(other.gameObject);
                if (destroySelfObject)
                    Destroy(gameObject);

                if (setOtherParent)
                    other.transform.SetParent(transform);
                if (setSelfParent)
                    transform.SetParent(other.transform);

                OnHit?.Invoke();
            }
            else if (typeFinder)
            {
                if (destroySelfOut)
                    Destroy(gameObject);
            }
        }
    }
}
