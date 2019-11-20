using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
	[SerializeField]
	protected Transform gravityTo;
	[SerializeField]
	protected float rotationSpeed;
	protected Vector3 DownDirection { get => gravityTo != null ? gravityTo.position - transform.position : transform.position; }
	protected Vector3 UpDirection { get => DownDirection * -1; }
	protected Vector3 GravitiDirection { get => gravityTo != null ? ClosestGravityPoint(transform.position) - transform.position : transform.position; }

	void FixedUpdate()
	{
		SetRotationUp();
	}

	protected Vector3 ClosestGravityPoint(Vector3 position)
	{
		var ray = new Ray(transform.position, DownDirection);
		if (Physics.Raycast(ray, out var hit))
		{
			if (hit.collider != null)
			{
				return hit.point;
			}
		}
		return gravityTo.position;
	}

	protected void SetRotationUp()
	{
		var _direction = UpDirection.normalized;
		var _lookRotation = Quaternion.LookRotation(_direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
	}
}
