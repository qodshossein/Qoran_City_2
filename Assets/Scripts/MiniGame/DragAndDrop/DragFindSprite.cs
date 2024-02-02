using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using MiniGame.Finder;

namespace MiniGame.DragAndDrop
{
    public class DragFindSprite : Drag
    {

        protected override void OnMouseUp()
        {
            base.OnMouseUp();
            if (!CanDrag) return;
            var slot = MouseData.SlotObject;
            if (slot)
            {
                var spriteFinder = slot.GetComponent<TypeFinder>();

                if (spriteFinder.Check(_spriteRenderer.sprite))
                    TrueSlot(slot);
                else
                    WrongSlot();
            }
            else
                WrongSlot();
        }
    }
}
