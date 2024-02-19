using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools_QC
{
    public class PointCreator3D : MonoBehaviour
    {
        [SerializeField] private float radius = 1;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public Vector3 GetPoint()
        {
            var point = Random.insideUnitSphere * radius;
            point += transform.position;
            point.y = transform.position.y;
            return point;
        }
    }
}
