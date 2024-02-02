using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
    public class MoveTween : AnimationTween
    {
        public override void Play()
        {
            base.Play();
            transform.DOMove(target.position, timeAnimation);
        }
    }
}
