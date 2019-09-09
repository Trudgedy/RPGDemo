using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoter))]
public class PlayerController : MonoBehaviour
{
	public LayerMask MovementMask;

	Camera camera;
	PlayerMoter playerMotor;


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
				//Move player
				playerMotor.MoveToPoint(hit.point);

				//stop focus
			}
		}
	}
}
