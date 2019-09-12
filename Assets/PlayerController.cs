using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoter))]
public class PlayerController : MonoBehaviour
{
	public LayerMask MovementMask;

	Camera camera;
	PlayerMoter playerMotor;
	public Interactable focus;

	// Start is called before the first frame update
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
	private void SetFocus(Interactable interactable)
	{
		focus = interactable;
		playerMotor.FollowTarget(interactable);
	}

	private void RemoveFocus()
	{
		focus = null;
		playerMotor.StopFollowingTarget();
	}


}
