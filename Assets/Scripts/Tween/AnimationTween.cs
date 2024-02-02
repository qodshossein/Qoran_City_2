using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tween
{
    public class AnimationTween : MonoBehaviour
    {
        [SerializeField] protected float timeAnimation;
        [SerializeField] protected Transform target;
        [SerializeField] protected bool playOnAwake;

        protected virtual void Awake() 
        {
            if (playOnAwake)
                Play();
        }
        public virtual void Play() 
        {

        }
    }
}
