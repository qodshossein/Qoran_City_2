using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools_QC
{
    public class LineControl : MonoBehaviour
    {
        [SerializeField] private Transform[] targetPositions;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();

            _lineRenderer.positionCount = targetPositions.Length;
        }

        private void Update()
        {
            for (int i = 0; i < targetPositions.Length; i++)
            {
                _lineRenderer.SetPosition(i, targetPositions[i].position);
            }
        }
    }
}
