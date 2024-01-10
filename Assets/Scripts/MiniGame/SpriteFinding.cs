using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class SpriteFinding : MonoBehaviour
    {
        public Sprite TargetSprite;

        public UnityEvent OnFindSprite;

        private void Awake()
        {
        }

        public bool CheckSprite(Sprite sprite) 
        {
            if(TargetSprite == sprite)
            {
                OnFindSprite?.Invoke();
                return true;
            }
            return false;
        }
    }
}
