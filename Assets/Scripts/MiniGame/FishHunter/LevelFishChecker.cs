using DG.Tweening;
using MiniGame.Collision;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.FishHunter
{
    public class LevelFishChecker : MonoBehaviour
    {
        [SerializeField] private bool destroyLevelFail;
        [SerializeField] private float scaleUpValue;
        public int Level = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var otherFish = collision.GetComponent<LevelFishChecker>();
            if (!otherFish) return;

            var otherLevel = otherFish.Level;
            if (otherLevel <= Level) 
            {

                Destroy(otherFish.gameObject);
                LevelUp();
            }
            else 
            {
                if (!destroyLevelFail)
                {
                    MiniGameController.Instance.OnFind();
                }
                else
                {
                    MiniGameController.Instance.LevelFail();
                }
            }
        }

        private void LevelUp() 
        {
            Level++;
            var targetscale = transform.localScale;
            targetscale *= 1 + scaleUpValue;
            transform.localScale = targetscale;
        }
    }
}
