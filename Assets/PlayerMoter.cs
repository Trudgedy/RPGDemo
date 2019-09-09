using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoter : MonoBehaviour
{

	NavMeshAgent navMeshagent;
    // Start is called before the first frame update
    void Start()
    {
		navMeshagent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void MoveToPoint(Vector3 destPoint)
	{
		navMeshagent.SetDestination(destPoint);
	}
}
