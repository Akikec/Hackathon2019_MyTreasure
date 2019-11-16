using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGravity : MonoBehaviour
{
	[SerializeField]
	private float gravityСoefficient;
	private Vector3 massCenter;
	void Start()
	{
		gravityСoefficient = 9.81f;
		massCenter = transform.position;
	}
	void Update()
	{
		CangeGarvityForceForChildrens();
	}

	private void CangeGarvityForceForChildrens()
	{
		var childrensRB = GetComponentsInChildren<Rigidbody>();
		foreach (var childRB in childrensRB)
		{
			var gravityForce = CountGravityForce(childRB);
			childRB.AddForce(gravityForce);
		}
	}

	private Vector3 CountGravityForce(Rigidbody rb)
	{
		var forceDirection = (massCenter - rb.position).normalized;
		var force = rb.mass * gravityСoefficient; //m*g
		var forceVector = forceDirection * force;
		return forceVector;
	}
}
