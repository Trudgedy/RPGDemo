using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoter : MonoBehaviour
{

	NavMeshAgent navMeshagent;
	Transform target;
    // Start is called before the first frame update
    void Start()
    {
		navMeshagent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
		{
			navMeshagent.SetDestination(target.position);
			FaceTarget();
		}
    }

	public void MoveToPoint(Vector3 destPoint)
	{
		navMeshagent.SetDestination(destPoint);
	}

	public void FollowTarget(Interactable newTarget)
	{
		navMeshagent.stoppingDistance = newTarget.radius * .8f;
		navMeshagent.updateRotation = false;
		target = newTarget.transform;
	}

	public void StopFollowingTarget()
	{
		navMeshagent.stoppingDistance = 0f;
		navMeshagent.updateRotation = true;
		target = null;
	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
