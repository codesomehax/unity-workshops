using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player.Movement
{
    public class NavMeshAgentMovement : MonoBehaviour
    {
        private static bool ShouldMove => Input.GetMouseButtonDown(0);
        
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (ShouldMove)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool hitSomething = Physics.Raycast(ray, out RaycastHit hitInfo);

                if (hitSomething)
                {
                    Vector3 clickedWorldPoint = hitInfo.point;
                    _navMeshAgent.SetDestination(clickedWorldPoint);
                }
            }
        }
    }
}