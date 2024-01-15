using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Finder;

namespace MiniGame.Controller.IceCream
{
    public class IceCream1Controller : MonoBehaviour
    {
        [SerializeField] private QueueController queueController;
        [SerializeField] private TypeFinder[] spriteFindings;

        private int _numberIceCream;
        private void Start()
        {
            for (int i = 1; i < spriteFindings.Length; i++)
            {
                var slot = spriteFindings[i].GetComponent<Slot>();
                slot.CanDrop = false;
            }
            for (int i = 0; i < spriteFindings.Length; i++)
            {
                spriteFindings[i].OnFindSprite.AddListener(OnSetIceCream);
            }

            var billBoard = spriteFindings[0].transform.GetChild(1);
            billBoard.gameObject.SetActive(true);
        }

        private void OnSetIceCream() 
        {
            queueController.NextQueue();
            _numberIceCream++;

            var lastObjectQueue = queueController.LastQueueObject;
            var billBoard = lastObjectQueue.GetChild(1);
            billBoard.gameObject.SetActive(true);
            lastObjectQueue.GetComponent<Slot>().CanDrop = true;


            if (_numberIceCream >= spriteFindings.Length)
            {
                GameManager.Instance.LevelCompelet();
            }
        }
    }
}
