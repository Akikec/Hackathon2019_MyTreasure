using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGravity : MonoBehaviour
{
	[SerializeField]
	private float gravityСoefficient;
	public Vector3 CenterMass { get => transform.position; }


	void Start()
	{
		gravityСoefficient = 9.81f;
	}

	public Vector3 GetGravityDirection(Rigidbody rb)
	{
		return CenterMass - rb.position;
	}

	public Vector3 CountGravityForce(Rigidbody rb)
	{
		var forceDirection = GetGravityDirection(rb).normalized;
		var force = rb.mass * gravityСoefficient; //m*g
		var forceVector = forceDirection * force;
		return forceVector;
	}
}
