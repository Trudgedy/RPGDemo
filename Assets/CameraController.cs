using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform Target;
	public Vector3 Offset;
	public float Pitch = 2f;

	public float ZoomSpeed = 4f;
	public float MinZoom = 5f;
	public float MaxZoom = 15f;
	private float CurrentZoom = 10f;

	private void Update()
	{
		CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
		CurrentZoom = Mathf.Clamp(CurrentZoom, MinZoom, MaxZoom);
	}

	void LateUpdate()
	{
		transform.position = Target.position - Offset * CurrentZoom;
		transform.LookAt(Target.position + Vector3.up * Pitch);
	}
  
}
