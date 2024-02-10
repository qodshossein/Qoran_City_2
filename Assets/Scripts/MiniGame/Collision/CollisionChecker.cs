using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame.Collision
{
    public class CollisionChecker : MonoBehaviour
    {
        [SerializeField] protected string[] targetTags;
        [SerializeField] protected bool destroySelfObject;
        [SerializeField] protected bool destroyOtherObject;
        [SerializeField] protected bool setOtherParent;
        [SerializeField] protected bool setSelfParent;
        public UnityEvent OnHit;

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if(CheckTag(other.gameObject.tag)) 
            {
                if(destroyOtherObject)
                    Destroy(other.gameObject);
                if (destroySelfObject)
                    Destroy(gameObject);

                if (setOtherParent)
                    other.transform.SetParent(transform);
                if (setSelfParent)
                    transform.SetParent(other.transform);
                OnHit?.Invoke();
            }
        }
        protected virtual bool CheckTag(string tag) 
        {
            for (int i = 0; i < targetTags.Length; i++)
            {
                if (targetTags[i] == tag) return true;
            }

            return false;
        }
    }
}
