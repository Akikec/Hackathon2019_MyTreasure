using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 1f;
	protected Vector3 move;
	protected Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		move.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		move.z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate(move);
		float mouseInput = Input.GetAxis("Mouse X");
		Vector3 lookhere = new Vector3(0, mouseInput, 0);
		transform.Rotate(lookhere);

		if (Input.GetKey(KeyCode.Space))
		{
			//rb.AddForce()
		}
	}
}