using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBodyGravitation : MonoBehaviour
{
	[SerializeField]
<<<<<<< HEAD
	private Transform gravityTo;
	private Rigidbody rb;
	[SerializeField] 
	private float gravityСoefficient;
=======
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
>>>>>>> origin/testGravity

	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

<<<<<<< HEAD
    void Update()
    {
		AddGravity();
=======
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
>>>>>>> origin/testGravity
	}


	protected void SetRotationUp()
	{
<<<<<<< HEAD
		var gravityForce = CountGravityForce(rb);
		rb.AddForce(gravityForce);
=======
		//transform.rotation = new Quaternion(UpDirection.x, UpDirection.y, UpDirection.z, 0);
>>>>>>> origin/testGravity
	}

	public Vector3 CountGravityForce(Rigidbody rb)
	{
		var forceDirection = (gravityTo.position - transform.position).normalized;
		var force = rb.mass * gravityСoefficient; //m*g
		var forceVector = forceDirection * force;
		return forceVector;
	}
}
