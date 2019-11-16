using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected Vector3 move;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal")*Time.deltaTime* moveSpeed;
        move.z = Input.GetAxis("Vertical")*Time.deltaTime* moveSpeed;
        transform.Translate(move);
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
    }
}
