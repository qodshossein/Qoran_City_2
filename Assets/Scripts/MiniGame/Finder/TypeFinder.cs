using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MiniGame.Finder
{
    public class TypeFinder : MonoBehaviour
    {
        public bool SelfSprite;
        public Sprite[] targetSprites;
        public string[] texts;
        public ColorType TargetColor;
        public TypeFinder[] otherChangeType;

        public UnityEvent OnFindSprite;

        private SpriteRenderer _spriteRenderer;
        private Text _text;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _text = GetComponent<Text>();
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

        public bool Check(string text)
        {
            if (SelfSprite && _text)
            {
                if (_text.text == text)
                {
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i] == text)
                {
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            return false;
        }
    }
}
