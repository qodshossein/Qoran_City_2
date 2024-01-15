using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.DragAndDrop;

namespace MiniGame.Controller.IceCream
{
    public class IceCream5Controller : MonoBehaviour
    {
        [SerializeField] private DragFindColor[] iceCreams;

        private int _numberIceCream;
        private void Start()
        {
            for (int i = 0; i < iceCreams.Length; i++)
            {
                iceCreams[i].OnDrop.AddListener(OnSetIceCream);
            }
        }
        private void OnSetIceCream()
        {
            _numberIceCream++;


            if (_numberIceCream >= iceCreams.Length)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
