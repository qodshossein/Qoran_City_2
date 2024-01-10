using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

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
                var spriteFinder = slot.GetComponent<SpriteFinding>();

                if (spriteFinder.CheckSprite(_spriteRenderer.sprite))
                {
                    transform.position = slot.TargetPosition.position;
                    transform.parent = slot.TargetPosition;
                    if (_spriteRenderer)
                        _spriteRenderer.sortingOrder = targetLayerOrder;

                    CanDrag = false;
                }
                else
                {
                    transform.position = _firstPos;
                    if (_spriteRenderer)
                        _spriteRenderer.sortingOrder = _firstLayer;
                }
            }
            else 
            {
                transform.position = _firstPos;
            }

        }
    }
}
