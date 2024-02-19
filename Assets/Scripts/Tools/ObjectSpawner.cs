using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools_QC
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform objectPrefab;

        public void Spawn() 
        {
            var objectSpawned = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
