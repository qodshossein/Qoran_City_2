using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class ChangeRandomPosition : MonoBehaviour
    {
        [SerializeField] private Transform[] objects;

        private void Awake()
        {
            ChangePositions();
        }

        private void ChangePositions() 
        {
            var positions = new List<Vector3>();
            for (int i = 0; i < objects.Length; i++)
                positions.Add(objects[i].position);

            for (int i = 0; i < objects.Length; i++)
            {
                var randomIndex = Random.Range(0, positions.Count);
                var pos = positions[randomIndex];
                objects[i].position = pos;
                positions.RemoveAt(randomIndex);
            }
        }
    }
}
