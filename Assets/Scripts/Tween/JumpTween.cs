using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
    public class JumpTween : AnimationTween
    {
        [SerializeField] private float powerJump;
        [SerializeField] private int numberJump;
        public override void Play()
        {
            base.Play();
            transform.DOLocalJump(target.position, powerJump, numberJump, timeAnimation).OnComplete(() => 
            {
                OnAnimationCompelet?.Invoke();
            });
        }
    }
}
