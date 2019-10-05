using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;
	Transform player;
	bool hasInteracted = false;

	public virtual void Interact()
	{
		//This will be overriden
		Debug.Log($"Interacting with {interactionTransform.name}");
	}

	private void Update()
	{
		if (isFocus && !hasInteracted)
		{
			var distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				Interact();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused(Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	public void OnDefocused()
	{
		hasInteracted = false;
		isFocus = false;
		player = null;
	}

	private void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}
