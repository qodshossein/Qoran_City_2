using Manager;
using MiniGame.DragAndDrop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Controller.Butiqe
{
    public class Butiqe4Controller : MonoBehaviour
    {
        [SerializeField] private int numberFind;
        [SerializeField] private CardChecker checker;

        private int _numberCloth;
        private void Start()
        {
            checker.OnFindRightCard.AddListener(OnSetCloth);
        }
        private void OnSetCloth()
        {
            _numberCloth++;


            if (_numberCloth >= numberFind)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
