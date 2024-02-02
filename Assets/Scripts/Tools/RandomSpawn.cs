using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class RandomSpawn : MonoBehaviour
    {
        [SerializeField] private Transform[] objects;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float spawnTime;

        private float _currentTime;
        private bool _canSpawn;

        private void Awake()
        {
            _currentTime = spawnTime;
        }
        private void Start()
        {
            _canSpawn = true;

            GameManager.Instance.OnLevelCompelet += OnLevelCompelet;
            GameManager.Instance.OnLevelFail += OnLevelFail;
        }
        private void OnDestroy()
        {
            GameManager.Instance.OnLevelCompelet -= OnLevelCompelet;
            GameManager.Instance.OnLevelFail -= OnLevelFail;
        }
        private void Update()
        {
            if (!_canSpawn) return;
            _currentTime -= Time.deltaTime;
            if(_currentTime <= 0)
            {
                Spawn();
                _currentTime = spawnTime;
            }
        }

        private void Spawn() 
        {
            var spawnPoint = GetSpawnPoint();
            var obj = GetObject();

            var objectSpawned = Instantiate(obj, spawnPoint.position, spawnPoint.rotation);
            Destroy(objectSpawned.gameObject, 15);
        }

        private Transform GetSpawnPoint() 
        {
            var randomIndex = Random.Range(0, spawnPoints.Length);
            var spawnPoint = spawnPoints[randomIndex];
            return spawnPoint;
        }
        private Transform GetObject()
        {
            var randomIndex = Random.Range(0, objects.Length);
            var obj = objects[randomIndex];
            return obj;
        }

        private void OnLevelCompelet()
        {
            _canSpawn = false;
        }
        private void OnLevelFail() 
        {
            _canSpawn = false;
        }
    }
}
