using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using MiniGame.Finder;

public enum ColorType { Blue, Green, Red, Yellow, Brown, Pink, White, Black, Orange }
namespace MiniGame.DragAndDrop
{
    public class DragFindColor : Drag
    {
        [SerializeField] private ColorType targetColor;

        protected override void OnMouseUp()
        {
            base.OnMouseUp();
            if (!CanDrag) return;
            var slot = MouseData.SlotObject;
            if (slot)
            {
                var spriteFinder = slot.GetComponent<TypeFinder>();

                if (spriteFinder.Check(targetColor))
                    TrueSlot(slot);
                else
                    WrongSlot();
            }
            else
                WrongSlot();
        }
    }
}
