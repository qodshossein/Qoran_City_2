using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Finder;

namespace MiniGame.Controller.IceCream
{
    public class IceCream3Controller : MonoBehaviour
    {
        [SerializeField] private TypeFinder[] spriteFindings;

        private int _numberIceCream;
        private void Start()
        {
            for (int i = 0; i < spriteFindings.Length; i++)
            {
                spriteFindings[i].OnFindSprite.AddListener(OnSetIceCream);
            }
        }
        private void OnSetIceCream()
        {
            _numberIceCream++;


            if (_numberIceCream >= spriteFindings.Length)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
