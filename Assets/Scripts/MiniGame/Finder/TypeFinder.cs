using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MiniGame.Finder
{
    public class TypeFinder : MonoBehaviour
    {
        public bool SelfSprite;
        public bool dontAddRepetitious;
        public bool addAny;
        public Sprite[] targetSprites;
        public string[] texts;
        public ColorType TargetColor;
        public TypeFinder[] otherChangeType;

        public UnityEvent OnFindSprite;

        private SpriteRenderer _spriteRenderer;
        private Text _text;

        [SerializeField] private List<Sprite> _addedSprites;
        private List<ColorType> _addedColors;
        private List<string> _addedTexts;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _text = GetComponent<Text>();

            _addedSprites = new List<Sprite>();
            _addedColors = new List<ColorType>();
            _addedTexts = new List<string>();
        }

        public bool Check(ColorType color) 
        {
            if (dontAddRepetitious)
            {
                for (int i = 0; i < _addedColors.Count; i++)
                {
                    if (_addedColors[i] == color)
                        return false;
                }
            }
            if (TargetColor == color)
            {
                _addedColors.Add(color);
                OnFindSprite?.Invoke();
                return true;
            }
            return false;
        }
        public bool Check(Sprite sprite)
        {
            if (dontAddRepetitious)
            {
                for (int i = 0; i < _addedSprites.Count; i++)
                {
                    if (_addedSprites[i] == sprite)
                        return false;
                }
            }
            if (SelfSprite && _spriteRenderer)
            {
                if (_spriteRenderer.sprite == sprite)
                {
                    _addedSprites.Add(sprite);
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            for (int i = 0; i < targetSprites.Length; i++)
            {
                if (targetSprites[i] == sprite)
                {
                    _addedSprites.Add(sprite);
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            return false;
        }

        public bool Check(string text)
        {
            if (dontAddRepetitious)
            {
                for (int i = 0; i < _addedTexts.Count; i++)
                {
                    if (_addedTexts[i] == text)
                        return false;
                }
            }
            if (SelfSprite && _text)
            {
                if (_text.text == text)
                {
                    _addedTexts.Add(text);
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i] == text)
                {
                    _addedTexts.Add(text);
                    OnFindSprite?.Invoke();
                    return true;
                }
            }
            return false;
        }

        public Sprite[] GetSprites() => _addedSprites.ToArray();
        public ColorType[] GetColors() => _addedColors.ToArray();
        public string[] GetTexts() => _addedTexts.ToArray();
    }
}
