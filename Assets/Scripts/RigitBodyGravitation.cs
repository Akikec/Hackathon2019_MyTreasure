using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBodyGravitation : MonoBehaviour
{
	[SerializeField]
	protected Collider gravityTo;
	[SerializeField]
	protected Transform centerOfMass;
	[SerializeField]
	protected float gravityScale;
	[SerializeField]
	protected float minGroundedDistance;
	protected Rigidbody rb;
	protected Vector3 GravitiDirection { get => gravityTo != null ? gravityTo.ClosestPoint(centerOfMass.position) - centerOfMass.position : centerOfMass.position; }
	public bool IsGrounded { get => GravitiDirection.sqrMagnitude <= minGroundedDistance * minGroundedDistance; }

	void Start()
    {
		rb = GetComponent<Rigidbody>();
		//rb.centerOfMass = centerOfMass.position;
	}

	void FixedUpdate()
	{
		AddGravityForce();
	}

	protected void AddGravityForce()
	{
		if (rb != null && rb.useGravity && !IsGrounded)
			AddForce(GravitiDirection * gravityScale * rb.mass);
	}

	protected void AddForce(Vector3 force)
	{
		rb?.AddForce(force);
	}

}
