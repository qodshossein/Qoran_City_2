using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class CardChecker : MonoBehaviour
    {
        [SerializeField] private CardSelect[] cardSelects;
        public UnityEvent OnFindRightCard;

        private CardSelect _firstCard;
        private CardSelect _secendCard;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < cardSelects.Length; i++) 
            {
                cardSelects[i].OnSelect.AddListener(OnCardSelect);
                cardSelects[i].Show();
            }
        }

        private void OnCardSelect(CardSelect card) 
        {
            if (!_firstCard) 
                _firstCard = card;
            else
            {
                _secendCard = card;
                Invoke(nameof(Check), 0.8f);
            }
        }

        private void Check()
        {
            if (!_firstCard || !_secendCard) return;
            if (_firstCard.sprite == _secendCard.sprite) 
            {
                OnFindRightCard?.Invoke();
            }
            else 
            {
                _firstCard.BackToFirstRotate();
                _secendCard.BackToFirstRotate();
            }
            _firstCard = null;
            _secendCard = null;
        }
    }
}
