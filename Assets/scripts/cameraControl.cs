using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform player;
    public float smoothFactor;
    public bool lookAtTarget = false;
    public float rotateLimiter;

    private float rotateY;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }


    private void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        rotateY = Input.GetAxis("Horizontal") * rotateLimiter;
        transform.Rotate(new Vector3(0, rotateY, 0));

      
    }

}
