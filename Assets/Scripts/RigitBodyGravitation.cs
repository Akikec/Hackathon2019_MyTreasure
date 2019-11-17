using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBodyGravitation : MonoBehaviour
{
	[SerializeField]
	protected Transform gravityTo;
	[SerializeField]
	protected float gravityScale;
	[SerializeField]
	protected float minGroundedDistance;
	protected Rigidbody rb;
	protected Vector3 DownDirection { get => gravityTo != null ? gravityTo.position - transform.position : transform.position; }
	protected Vector3 UpDirection { get => UpDirection * -1; }
	protected Vector3 GravitiDirection { get => gravityTo != null ? ClosestGravityPoint(transform.position) - transform.position : transform.position; }
	public bool IsGrounded { get => GravitiDirection.sqrMagnitude <= minGroundedDistance * minGroundedDistance; }

	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		AddGravityForce();
		SetRotationUp();
	}

	protected void AddGravityForce()
	{
		if (!IsGrounded)
			rb?.AddForce(GravitiDirection.normalized * gravityScale * rb.mass);
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
		//transform.rotation = new Quaternion(UpDirection.x, UpDirection.y, UpDirection.z, 0);
	}
}
