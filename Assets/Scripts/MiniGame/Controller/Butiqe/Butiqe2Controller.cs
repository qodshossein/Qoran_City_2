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

        private int _numberIceCream;
        private void Start()
        {
            for (int i = 0; i < cloths.Length; i++)
            {
                cloths[i].OnDrop.AddListener(OnSetIceCream);
            }
        }
        private void OnSetIceCream()
        {
            _numberIceCream++;


            if (_numberIceCream >= cloths.Length)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
