using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Finder;

namespace MiniGame.Controller.IceCream
{
    public class IceCream1Controller : MiniGameController
    {
        [SerializeField] private QueueController queueController;

        protected override void Start()
        {
            base.Start();
            for (int i = 1; i < objectFinder.Length; i++)
            {
                var slot = objectFinder[i].GetComponent<Slot>();
                slot.CanDrop = false;
            }

            var billBoard = objectFinder[0].transform.GetChild(1);
            billBoard.gameObject.SetActive(true);
        }

        public override void OnFind()
        {
            base.OnFind();
            queueController.NextQueue();

            var lastObjectQueue = queueController.LastQueueObject;
            var billBoard = lastObjectQueue.GetChild(1);
            billBoard.gameObject.SetActive(true);
            lastObjectQueue.GetComponent<Slot>().CanDrop = true;
        }
    }
}
