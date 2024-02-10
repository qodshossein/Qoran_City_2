using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class PointCreator2D : MonoBehaviour
    {
        [SerializeField] private float radius = 1;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public Vector2 GetPoint() 
        {
            var point = Random.insideUnitSphere * radius;
            point += transform.position;
            return point;
        }
    }
}
