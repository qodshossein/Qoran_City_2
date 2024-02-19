using System.Collections;
using System.Collections.Generic;
using Tools_QC;
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
            if (!CanDrag) return;
            var slot = MouseData.SlotObject;
            if (slot)
            {
                var spriteFinder = slot.GetComponent<TypeFinder>();

                if (spriteFinder)
                {
                    if (spriteFinder.addAny)
                        TrueSlot(slot);
                    else
                    {
                        if (spriteFinder.Check(_spriteRenderer.sprite))
                            TrueSlot(slot);
                        else
                            WrongSlot();
                    }
                }
                else
                    TrueSlot(slot);
            }
            else
                WrongSlot();

            base.OnMouseUp();
        }
    }
}
