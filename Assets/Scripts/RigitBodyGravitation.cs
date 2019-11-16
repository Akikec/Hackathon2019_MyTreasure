using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigitBodyGravitation : MonoBehaviour
{
	[SerializeField]
	private WorldGravity world;
	private Rigidbody rb;
	[SerializeField] private float jumpCoeff;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
		AddGravity();
		if (Input.GetMouseButtonDown(0))
		{
			var gravityForce = world.GetGravityDirection(rb);
			var jumpForce = -1 * jumpCoeff * gravityForce;
			rb.AddForce(jumpForce);
		}
	}

	private void AddGravity()
	{
		var gravityForce = world.CountGravityForce(rb);
		rb.AddForce(gravityForce);
	}
}
