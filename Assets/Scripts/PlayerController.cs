using UnityEngine;

[RequireComponent(typeof(PlayerMoter))]
public class PlayerController : MonoBehaviour
{
	public LayerMask MovementMask;

	Camera camera;
	PlayerMoter playerMotor;
	public Interactable focus;

	void Start()
	{
		camera = Camera.main;
		playerMotor = GetComponent<PlayerMoter>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray clickRay = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(clickRay, out hit, 100, MovementMask))
			{
				playerMotor.MoveToPoint(hit.point);

				RemoveFocus();
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			Ray clickRay = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(clickRay, out hit, 100))
			{
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				if (interactable != null)
				{
					SetFocus(interactable);
				}

			}
		}
	}
	private void SetFocus(Interactable newFocus)
	{
		if (newFocus != focus)
		{
			if (focus != null)
				focus.OnDefocused();
			focus = newFocus;
			playerMotor.FollowTarget(newFocus);
		}
		newFocus.OnFocused(transform);
	}

	private void RemoveFocus()
	{
		if (focus != null)
			focus.OnDefocused();

		focus = null;
		playerMotor.StopFollowingTarget();
	}


}
