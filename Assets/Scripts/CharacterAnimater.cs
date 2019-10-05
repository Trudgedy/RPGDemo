using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimater : MonoBehaviour
{
	const float LocolmotionAnimationSmoothTime = .1f;

	Animator animator;
	NavMeshAgent agent;
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
	}


	void Update()
	{
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat("speedPercent", speedPercent, LocolmotionAnimationSmoothTime, Time.deltaTime);

	}
}
