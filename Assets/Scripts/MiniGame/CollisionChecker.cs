using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class CollisionChecker : MonoBehaviour
    {
        [SerializeField] private string[] targetTags;
        [SerializeField] private bool destroySelfObject;
        [SerializeField] private bool destroyOtherObject;
        public UnityEvent OnHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(CheckTag(other.gameObject.tag)) 
            {
                if(destroyOtherObject)
                    Destroy(other.gameObject);
                if (destroySelfObject)
                    Destroy(gameObject);
                OnHit?.Invoke();
            }
        }
        private bool CheckTag(string tag) 
        {
            for (int i = 0; i < targetTags.Length; i++)
            {
                if (targetTags[i] == tag) return true;
            }

            return false;
        }
    }
}
