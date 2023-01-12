using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMovement : MonoBehaviour
{
    private static bool ShouldMove => Input.GetMouseButtonDown(0);
    
    private NavMeshAgent _navMeshAgent;
    
    private void Start()
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
                Vector3 destination = hitInfo.point;
                _navMeshAgent.SetDestination(destination);
            }
        }
    }
}
