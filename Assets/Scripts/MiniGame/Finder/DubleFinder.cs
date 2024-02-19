using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Finder
{
    public class DubleFinder : MonoBehaviour
    {
        [SerializeField] private Slot slot1;
        [SerializeField] private Slot slot2;

        private void Start()
        {
            slot1.OnDrop.AddListener(CheckSlots);
            slot2.OnDrop.AddListener(CheckSlots);
        }

        private void CheckSlots()
        {
            if (slot1.transform.childCount < 1 || slot2.transform.childCount < 1) return;
            var object1 = slot1.transform.GetChild(0);
            var object2 = slot2.transform.GetChild(0);

            var sprite1 = object1.GetComponent<SpriteRenderer>();
            var sprite2 = object2.GetComponent<SpriteRenderer>();

            if (sprite1.sprite == sprite2.sprite)
            {
                DestroyObjects();
            }
        }

        private void DestroyObjects() 
        {
            var object1 = slot1.transform.GetChild(0);
            var object2 = slot2.transform.GetChild(0);

            object1.DOScale(0, 0.3f);
            object2.DOScale(0, 0.3f);

            Destroy(object1.gameObject, 0.3f);
            Destroy(object2.gameObject, 0.3f);

            slot1.CanDrop = true;
            slot2.CanDrop = true;

            MiniGameController.Instance.OnFind();
        }
    }
}
