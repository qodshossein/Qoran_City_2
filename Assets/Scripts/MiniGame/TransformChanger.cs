using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class TransformChanger : MonoBehaviour
    {
        [SerializeField] private Transform targetPosition;
        public void ChangePosition() 
        {
            transform.position = targetPosition.position;
        }
        public void ChangeParent(Transform parent) 
        {
            transform.SetParent(parent);
        }
    }
}
