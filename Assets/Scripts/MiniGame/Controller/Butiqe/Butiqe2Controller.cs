using Manager;
using MiniGame.DragAndDrop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Controller.Butiqe
{
    public class Butiqe2Controller : MonoBehaviour
    {
        [SerializeField] private DragFindSprite[] cloths;

        private int _numberCloth;
        private void Start()
        {
            for (int i = 0; i < cloths.Length; i++)
            {
                cloths[i].OnDrop.AddListener(OnSetCloth);
            }
        }
        private void OnSetCloth()
        {
            _numberCloth++;


            if (_numberCloth >= cloths.Length)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
