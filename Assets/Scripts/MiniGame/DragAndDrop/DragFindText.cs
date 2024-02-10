using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using MiniGame.Finder;
using UnityEngine.UI;

namespace MiniGame.DragAndDrop
{
    public class DragFindText : Drag
    {
        private Text _text;

        protected override void Start()
        {
            base.Start();
            _text = GetComponent<Text>();
        }
        protected override void OnMouseUp()
        {
            if (!CanDrag) return;
            var slot = MouseData.SlotObject;
            if (slot)
            {
                var spriteFinder = slot.GetComponent<TypeFinder>();

                if (spriteFinder.Check(_text.text))
                    TrueSlot(slot);
                else
                    WrongSlot();
            }
            else
                WrongSlot();

            base.OnMouseUp();
        }
    }
}
