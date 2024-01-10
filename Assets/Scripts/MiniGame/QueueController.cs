using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MiniGame
{
    public class QueueController : MonoBehaviour
    {
        [SerializeField] private List<Transform> queueObjects;
        [SerializeField] private Transform exitPoint;

        public Transform LastQueueObject;
        public void NextQueue() 
        {
            for (int i = 1; i < queueObjects.Count; i++)
            {
                queueObjects[i].DOMove(queueObjects[i - 1].position, 1);
            }

            if (queueObjects.Count >= 2)
                LastQueueObject = queueObjects[1];
            if (queueObjects.Count > 0)
            {
                queueObjects[0].DOMove(exitPoint.position, 5);
                queueObjects.RemoveAt(0);
            }
        }
    }
}
