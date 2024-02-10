using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace MiniGame
{
    public class Slot : MonoBehaviour
    {
        public bool JustOnDrop = true;
        public Transform TargetPosition;
        public PointCreator2D[] pointCreators;
        public bool CanDrop {  get; set; }

        private void Awake()
        {
            CanDrop = true;
        }
        private void OnMouseEnter()
        {
            if (!CanDrop) return;
            if (MouseData.DragObject)
                MouseData.SlotObject = this;
        }
        private void OnMouseExit()
        {
            if (!CanDrop) return;
            if (MouseData.SlotObject == this)
                MouseData.SlotObject = null;
        }
    }
}
