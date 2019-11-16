using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;

    //[Range(0.01f, 1.0f)]
    //public float SmoothFactor = 0.5f;

    public float height = 5f;

    public float distance = 7f;

    //public float turnSpeed = 4.0f;

    [SerializeField]
    private bool lookAt = true;

    private Vector3 offsetX;
    //private Vector3 offsetY;

    void Start()
    {

        offsetX = new Vector3(0, height, -distance);
        //offsetY = new Vector3(0, 0, distance);
    }

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        //offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;

        //transform.position = player.TransformPoint(offsetX+offsetY);
        transform.position = player.TransformPoint(offsetX);


        // compute rotation
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}
