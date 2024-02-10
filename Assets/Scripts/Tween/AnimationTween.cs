using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tween
{
    public class AnimationTween : MonoBehaviour
    {
        [SerializeField] protected float timeAnimation;
        [SerializeField] protected Transform target;
        [SerializeField] protected bool playOnAwake;
        public UnityEvent OnAnimationCompelet;

        protected virtual void Awake() 
        {
            if (playOnAwake)
                Play();
        }
        public virtual void Play() 
        {
            transform.DOPause();
        }
    }
}
