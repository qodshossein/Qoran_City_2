using System.Collections;
using System.Collections.Generic;
using Tools_QC;
using UnityEngine;
using UnityEngine.AI;

namespace Shop
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private PointCreator3D[] pointCreators;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            Move();
        }
        private void Update()
        {
            if(_agent.remainingDistance <= _agent.stoppingDistance)
                Move();
        }
        private void Move()
        {
            _agent.SetDestination(GetPoint());
        }
        private Vector3 GetPoint() 
        {
            var randomIndex = Random.Range(0, pointCreators.Length);
            return pointCreators[randomIndex].GetPoint();
        }
    }
}
