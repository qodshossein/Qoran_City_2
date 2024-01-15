using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame.Finder
{
    public class TypeFinder : MonoBehaviour
    {
        public bool SelfSprite;
        public Sprite[] targetSprites;
        public ColorType TargetColor;

        public UnityEvent OnFindSprite;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool Check(ColorType color) 
        {
            if(TargetColor == color)
            {
                OnFindSprite?.Invoke();
                return true;
            }
            return false;
        }
        public bool Check(Sprite sprite)
        {
            if (SelfSprite && _spriteRenderer)
            {
                if (_spriteRenderer.sprite == sprite)
                {
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            for (int i = 0; i < targetSprites.Length; i++)
            {
                if (targetSprites[i] == sprite)
                {
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            return false;
        }
    }
}
