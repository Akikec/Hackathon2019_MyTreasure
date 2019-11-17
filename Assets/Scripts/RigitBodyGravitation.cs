using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBodyGravitation : MonoBehaviour
{
	[SerializeField]
	private Transform gravityTo;
	private Rigidbody rb;
	[SerializeField] 
	private float gravityСoefficient;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
		AddGravity();
	}

	private void AddGravity()
	{
		var gravityForce = CountGravityForce(rb);
		rb.AddForce(gravityForce);
	}

	public Vector3 CountGravityForce(Rigidbody rb)
	{
		var forceDirection = (gravityTo.position - transform.position).normalized;
		var force = rb.mass * gravityСoefficient; //m*g
		var forceVector = forceDirection * force;
		return forceVector;
	}
}
